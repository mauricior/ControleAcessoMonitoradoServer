using Connection.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class AcessoDadosSqlServer
    {

        private static readonly AcessoDadosSqlServer instance = new AcessoDadosSqlServer();
        private string dataSource;
        private string dataBase;
        private string user;
        private string senha;
        
        

        #region Atributos Classe
        public String DataSource
        {
            get { return this.dataSource; }
            set { this.dataSource = value; }
        }

        public String DataBase
        {
            get { return this.dataBase; }
            set { this.dataBase = value; }
        }

        public String User
        {
            get { return this.user; }
            set { this.user = value; }
        }
        public String Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }
        #endregion

        //Padrão Singleton
        public static AcessoDadosSqlServer Instance
        {
            get
            {
                return instance;
            }
        }


        private string stringConexao()
        {
            string connectionString;

            if (user == null && senha == null)
            {
                /*connectionString = @"Data Source =.\" + dataSource + ";" + "Initial Catalog=" + dataBase + ";" + "Integrated Security = True" + ";" +
                "Connect Timeout = 30;" + "User Instance = True;";*/
                //connectionString = "Data Source = MAURICIO-PC; Initial Catalog = AcessoMonitorado1; Integrated Security = True";
                connectionString = "Data Source = " + dataSource + "; Initial Catalog = " + dataBase + "; Integrated Security = True";
            }
            else
            {
                connectionString = @"Data Source =" + dataSource + ";" + "Initial Catalog=" + dataBase + ";" + "User ID=" + user + ";Password=" + senha;
                //connectionString = "Data Source = MAURICIO-PC; Initial Catalog = AcessoMonitorado1; User ID = sa; Password= root";
            }

            return connectionString;
        }

        //Cria a conexão 
        private SqlConnection CriarConexao()
        {

            //return new SqlConnection(Settings.Default.stringConexao);
            return new SqlConnection(stringConexao());
        }

        //Parâmetros que vão para o banco
        private SqlParameterCollection sqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametros()
        {
            sqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            sqlParameterCollection.Add(new SqlParameter(nomeParametro, valorParametro));
        }

        //Persistência - Inserir, Alterar, Excluir
        public object ExecutarManipulacao(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                //Criar a conexão
                SqlConnection sqlConnection = CriarConexao();
                //Abrir conexão
                sqlConnection.Open();
                //Criar o comando que vai levar informação para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Colocando as coisas dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200; // Em Segundos

                //Adicionar os parâmetros do comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));


                //Executar o comando
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        //Consultar registros do banco de dados
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoredProcedureOuTextoSql)
        {
            try
            {
                //Criar a conexão
                SqlConnection sqlConnection = CriarConexao();
                //Abrir conexão
                sqlConnection.Open();
                //Criar o comando que vai levar informação para o banco
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                //Colocando as coisas dentro do comando
                sqlCommand.CommandType = commandType;
                sqlCommand.CommandText = nomeStoredProcedureOuTextoSql;
                sqlCommand.CommandTimeout = 7200; // Em Segundos

                //Adicionar os parâmetros do comando
                foreach (SqlParameter sqlParameter in sqlParameterCollection)
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName, sqlParameter.Value));


                //Criar um adaptador
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                //DataTable = Tabela de Dados vazia
                DataTable dataTable = new DataTable();

                //Preencher DataTable
                sqlDataAdapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public string verificaConexao()
        {
            string retorno;
            try
            {
                //Criar a conexão
                SqlConnection sqlConnection = CriarConexao();
                //Abrir conexão
                sqlConnection.Open();
                retorno = "1";
            }
            catch(Exception ex)
            {
                retorno = "0";
            }

            return retorno;
        }

    }
}

