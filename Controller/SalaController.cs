using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using Model;


namespace Controller
{
    public class SalaController
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Sala sala)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", sala.Identificacao);
                acessoDadosSqlServer.AdicionarParametros("@Tipo", sala.Tipo);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "SalaInserir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public string Alterar(Sala sala)
        {
            string retorno;
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdSala", sala.IdSala);
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", sala.Identificacao);
                acessoDadosSqlServer.AdicionarParametros("@Tipo", sala.Tipo);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "SalaAlterar");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public string Excluir(Sala sala)
        {
            string retorno;
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdSala", sala.IdSala);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "SalaExcluir");
                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        //Consulta TODAS AS SALAS no banco de dados
        public List<Sala> ConsultaTudo()
        {
            Sala sala = new Sala();
            List<Sala> salas = new List<Sala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();


                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "SalaConsultaTudo");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                salas = (from DataRow dataRowLinha in dataTableSala.Rows
                         select new Sala
                         {
                             IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                             Identificacao = Convert.ToString(dataRowLinha["Identificacao"]),
                             Tipo = Convert.ToString(dataRowLinha["Tipo"])
                         }).ToList();


            }
            catch (Exception ex)
            {
                salas = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return salas;
        }

        //Consulta por Id no banco de dados a Sala
        public List<Sala> ConsultaPorId(int idSala)
        {
            Sala sala = new Sala();
            List<Sala> salas = new List<Sala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdSala", idSala);

                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "SalaConsultaPorId");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                salas = (from DataRow dataRowLinha in dataTableSala.Rows
                         select new Sala
                         {
                             IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                             Identificacao = Convert.ToString(dataRowLinha["Identificacao"]),
                             Tipo = Convert.ToString(dataRowLinha["Tipo"])
                         }).ToList();

            }
            catch (Exception ex)
            {
                salas = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return salas;
        }

        //Consulta por Identificacao no banco de dados a Sala
        public List<Sala> ConsultaPorIdentificacao(string identificacaoSala)
        {
            Sala sala = new Sala();
            List<Sala> salas = new List<Sala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", identificacaoSala);

                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "SalaConsultaPorIdentificacao");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                salas = (from DataRow dataRowLinha in dataTableSala.Rows
                         select new Sala
                         {
                             IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                             Identificacao = Convert.ToString(dataRowLinha["Identificacao"]),
                             Tipo = Convert.ToString(dataRowLinha["Tipo"])
                         }).ToList();


            }
            catch (Exception ex)
            {
                salas = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return salas;
        }
    }
}

