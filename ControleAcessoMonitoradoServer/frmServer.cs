using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                string ip = cbIp.SelectedItem.ToString();
                int porta = Convert.ToInt32(tbPortaServidor.Text);
                
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
            DialogResult resultado = MessageBox.Show("Parar o servidor pode ocasionar erros no funcionamento do sistema. \n Deseja realmente parar o servidor?",
                "Servidor Controle de Acesso Monitorado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (resultado == DialogResult.Yes)
            {
                CloseAllSockets();
                lbStatus.ForeColor = Color.Red;
                lbStatus.Text = "OFFLINE";
                btIniciarServidor.Enabled = true;
                btPararServidor.Enabled = false;
            }
            
        }


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
            LingerOption lo = new LingerOption(false, 0);

            foreach (Socket socket in clienteSockets)
            {
                
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
               
            }

           
            serverSocket.Close();
            AtualizarTextBox("Servidor desligado com sucesso. \r\n");
        }

        private static void DesconectarCallback(IAsyncResult ar)
        {
            
            Socket socket = (Socket)ar.AsyncState;
            
            socket.EndDisconnect(ar);
            
            
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                //if (serverSocket != null && serverSocket.Connected)
                
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

            

            //Supervisao supervisao = new Supervisao();

            /*if (supervisao.consultaPermissao(tag, identSala) == 1)
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
            }*/


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

        
    }
}
        

