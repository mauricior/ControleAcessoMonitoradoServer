﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Connection;
using Controller;

namespace ControleAcessoMonitoradoServer
{
    public partial class frmServer : Form
    {

       
        private static readonly List<Socket> clienteSockets = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];
        private Socket serverSocket;
        //Pegar IP do LOCALHOST
        private static string nomeMaquina = Dns.GetHostName();
        IPAddress[] ip = Dns.GetHostAddresses(nomeMaquina);
        //Instancias SQLServer
        DataTable dataTable = SqlDataSourceEnumerator.Instance.GetDataSources();


        //Delegate e método de atualizar o textbox Console
        delegate void OutputUpdateDelegate(string dado);

        public void AtualizarTextBox(string dado)
        {
            if (tbConsole.InvokeRequired)
                tbConsole.Invoke(new OutputUpdateDelegate(OutputUpdateCallback), new object[] { dado });
            else
                OutputUpdateCallback(dado);
        }

        private void OutputUpdateCallback(string dado)
        {
            tbConsole.AppendText(dado);
        }


        public frmServer()
        {
            InitializeComponent();
            tbConsole.AppendText("Servidor Controle de Acesso Monitorado \r\n");
            
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            //Adiciona o IPV4 ao COMBOBOX
            cbIp.Items.Add(ip[1]);
            cbIp.SelectedIndex = 0;
            btPararServidor.Enabled = false;

            configuracoesServidorBancoDados();

            //Adiciona nomes dos Servidores SQLSERVER  disponiveis ao cbNomeServidor.
            RecuperarNomeServidorInstancia();
            cbNomeServidor.SelectedIndex = 0;
            RecuperarNomeDataBases();
            cbNomeBancoDados.SelectedIndex = 0;
            

        }


        //Método que busca nome dos Servidores SQLSERVER locais e na rede. 
        private void MostrarDados(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                cbNomeServidor.Items.Add(row["ServerName"]);
                cbNomeBancoDados.Items.Add(row["InstanceName"]);
            }

            
        }

        private  void RecuperarNomeServidorInstancia()
        {
            //List<String> ServerNames = new List<String>();

            SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
            DataTable serversTable = servers.GetDataSources();

            foreach (DataRow row in serversTable.Rows)
            {
                string serverName = row[0].ToString();

                try
                {
                    if (row[1].ToString() != "")
                    {

                        serverName += "\\" + row[1].ToString();

                    }
                }
                catch
                {


                }

                cbNomeServidor.Items.Add(serverName);

            }
        }

        private void RecuperarNomeDataBases()
        {
            List<String> databases = new List<String>();

            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();

            connection.DataSource = cbNomeServidor.SelectedItem.ToString();
            // enter credentials if you want
            //connection.UserID = //get username;
            // connection.Password = //get password;
            connection.IntegratedSecurity = true;

            String strConn = connection.ToString();

            //create connection
            SqlConnection sqlConn = new SqlConnection(strConn);

            //open connection
            sqlConn.Open();

            //get databases
            DataTable tblDatabases = sqlConn.GetSchema("Databases");

            //close connection
            sqlConn.Close();

            //add to list
            foreach (DataRow row in tblDatabases.Rows)
            {
                String strDatabaseName = row["database_name"].ToString();

                //databases.Add(strDatabaseName);
                cbNomeBancoDados.Items.Add(strDatabaseName);

            }
        }

        private void configuracoesServidorBancoDados()
        {
            //Configurações do Servidor do Banco de Dados
            cbAutenticacao.Items.Add("Autenticação do Windows");
            cbAutenticacao.Items.Add("Autenticação do SQL Server");
            cbAutenticacao.SelectedIndex = 0;
            btDesconectarBancoDados.Enabled = false;

            
        }


        //Evento que administra o cbAutenticação das configurações do Banco de Dados
        private void cbAutenticacao_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbAutenticacao.SelectedItem.Equals("Autenticação do Windows"))
            {
                if(cbNomeUsuario.Items.Count > 1)
                {
                    cbNomeUsuario.SelectedIndex = 0;
                }

                cbNomeUsuario.Items.Add(System.Environment.UserDomainName + "/" + System.Environment.UserName);
                cbNomeUsuario.SelectedIndex = 0;
                lbNomeUsuario.Enabled = false;
                lbSenha.Enabled = false;
                cbNomeUsuario.Enabled = false;
                tbSenha.Enabled = false;

            }
            if (cbAutenticacao.SelectedItem.Equals("Autenticação do SQL Server"))
            {
                cbNomeUsuario.Items.RemoveAt(0);
                lbNomeUsuario.Enabled = true;
                lbSenha.Enabled = true;
                cbNomeUsuario.Enabled = true;
                tbSenha.Enabled = true;
                cbNomeUsuario.Items.Add("sa");
                cbNomeUsuario.SelectedItem = "sa";

            }
        }


        private void btIniciarServidor_Click(object sender, EventArgs e)
        {
            try
            {

                //Variáveis que são passadas pelo usuário no form
                string ip = cbIp.SelectedItem.ToString();
                int porta = Convert.ToInt32(tbPortaServidor.Text);
                
                //Se o método SetupServer retornar 1, significa que o servidor está rodando.
                if(SetupServer(ip, porta).Equals("1"))
                {
                    lbStatus.ForeColor = Color.Green;
                    lbStatus.Text = "ONLINE";
                    btIniciarServidor.Enabled = false;
                    btPararServidor.Enabled = true;
                }

               
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor preencha os campos de configuração antes de iniciar o servidor!", "Configurações do Servidor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            } 
                   
           
        }


        private void btPararServidor_Click(object sender, EventArgs e)
        {
            //Pergunta se o Usuário tem certeza em fechar o servidor.
            DialogResult resultado = MessageBox.Show("Parar o servidor pode ocasionar erros no funcionamento do sistema. \n Deseja realmente parar o servidor?",
                "Servidor Controle de Acesso Monitorado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            //Caso sim, fecha o Socket TCP/IP do servidor
            if (resultado == DialogResult.Yes)
            {
                CloseAllSockets();
                lbStatus.ForeColor = Color.Red;
                lbStatus.Text = "OFFLINE";
                btIniciarServidor.Enabled = true;
                btPararServidor.Enabled = false;
            }
            
        }


        //Método que cria o Servidor.
        private string SetupServer(string ip, int porta)
        {
           
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ip), porta));
                AtualizarTextBox("Servidor iniciado com sucesso! \r\n");
                AtualizarTextBox("Aguardando clientes... \r\n");
                serverSocket.Listen(0);
                serverSocket.BeginAccept(AcceptCallback, null);

                return "1";
          
        }

        private void CloseAllSockets()
        {
            
            foreach (Socket socket in clienteSockets)
            {
                
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
               
            }

            serverSocket.Close();
            AtualizarTextBox("Servidor desligado com sucesso. \r\n");
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                    socket = serverSocket.EndAccept(AR);

            }
            catch (ObjectDisposedException)
            {
                return;
            }


            clienteSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            serverSocket.BeginAccept(AcceptCallback, null);
            AtualizarTextBox("Cliente conectado, aguardando dados...\r\n");
            
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;

            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                AtualizarTextBox("Cliente foi desconectado inesperadamente\r\n");
                current.Close();
                clienteSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            //Console.WriteLine("Received Text: " + text);
            AtualizarTextBox("\r\n");
            AtualizarTextBox("\r\n");
            AtualizarTextBox("Foi recebido: ");
            string[] comando = text.Split(':');

            string id = "0";
            string tag = "0";
            string identSala = "0";
            string senha = "0";

            /*foreach(var item in comando)
            {
                    id = item.ToString();
                    tag = item.ToString();
                    identSala = item.ToString();
                    senha = item.ToString();
                
            }*/

            if (comando.Count() > 0)
            {
                id = comando[0];
            }
            if (comando.Count() > 1)
            {
                tag = comando[1];
            }
            if (comando.Count() > 2)
            {
                identSala = comando[2];
            }
            if (comando.Count() > 3)
            {
                senha = comando[3];
            }

            AtualizarTextBox("\r\n");
            AtualizarTextBox("\r\n");
            AtualizarTextBox("ID: " + id + " ");
            AtualizarTextBox("Tag: " + tag + " ");
            AtualizarTextBox("IdentSala: " + identSala + " ");
            AtualizarTextBox("Senha: " + senha + " ");
            AtualizarTextBox("\r\n");

            

            Supervisao supervisao = new Supervisao();

           if (supervisao.consultaPermissao(tag, identSala) == 1)
            {

                if (supervisao.verificaSenha(senha) == 1)
                {
                    byte[] data = Encoding.ASCII.GetBytes("Acesso liberado!");
                    current.Send(data);
                }
                else
                {
                    byte[] data = Encoding.ASCII.GetBytes("Saida registrada!");
                    current.Send(data);
                }
            }
            else
            {
                byte[] data = Encoding.ASCII.GetBytes("Você não possui permissão!");
                current.Send(data);
            }


             if (text.ToLower() == "get time") // Client requested time
             {
                 Console.WriteLine("Text is a get time request");
                 byte[] resposta = Encoding.ASCII.GetBytes(DateTime.Now.ToLongTimeString());
                 current.Send(resposta);
                 Console.WriteLine("Time sent to client");
             }
             else if (text.ToLower() == "exit") // Client wants to exit gracefully
             {
                 // Always Shutdown before closing
                 current.Shutdown(SocketShutdown.Both);
                 current.Close();
                 clienteSockets.Remove(current);
                 Console.WriteLine("Client disconnected");
                 return;
             }
             else
             {
                 Console.WriteLine("Text is an invalid request");
                 byte[] resposta = Encoding.ASCII.GetBytes("Invalid request");
                 current.Send(resposta);
                 Console.WriteLine("Warning Sent");
             }

            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }

        private void btConectarBancoDados_Click(object sender, EventArgs e)
        {
            AcessoDadosSqlServer acessoDadosSqlServer;

            if (cbAutenticacao.SelectedItem.Equals("Autenticação do Windows"))
            {
                string dataSource = cbNomeServidor.SelectedItem.ToString();
                string dataBase = cbNomeBancoDados.SelectedItem.ToString();
                acessoDadosSqlServer = new AcessoDadosSqlServer(dataSource, dataBase);
               
            }
            if(cbAutenticacao.SelectedItem.Equals("Autenticação do SQL Server"))
            {
                string dataSource = cbNomeServidor.SelectedItem.ToString();
                string dataBase = cbNomeBancoDados.SelectedItem.ToString();
                string user = cbNomeUsuario.SelectedItem.ToString();
                string senha = tbSenha.Text.ToString();
                acessoDadosSqlServer = new AcessoDadosSqlServer(dataSource, dataBase, user, senha);
                
            }
            
        }
    }
}
        

