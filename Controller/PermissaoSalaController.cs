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
    public class PermissaoSalaController
    {
        AcessoDadosSqlServer acessoDadosSqlServer = AcessoDadosSqlServer.Instance;

        public string Inserir(PermissaoSala permissaoSala)
        {
            string retorno;
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdSala", permissaoSala.IdSala);
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", permissaoSala.IdUsuario);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "PermissaoSalaInserir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public string Alterar(PermissaoSala permissaoSala)
        {
            string retorno;
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdSala", permissaoSala.IdSala);
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", permissaoSala.IdUsuario);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "PermissaoSalaAlterar");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public string Excluir(PermissaoSala permissaoSala)
        {
            string retorno;
            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPermissaoSala", permissaoSala.IdPermissaoSala);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "PermissaoSalaExcluir");
                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        //Consulta TODAS AS PERMISSOES no banco de dados
        public List<PermissaoSala> ConsultaPorTudo()
        {
            PermissaoSala permissaoSala = new PermissaoSala();
            List<PermissaoSala> permissaoSalas = new List<PermissaoSala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();

                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PermissaoSalaConsultaTudo");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                permissaoSalas = (from DataRow dataRowLinha in dataTableSala.Rows
                                  select new PermissaoSala
                                  {
                                      IdPermissaoSala = Convert.ToInt32(dataRowLinha["IdPermissaoSala"]),
                                      IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                                      IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"])
                                  }).ToList();




                //Retorna a lista de objetos
                return permissaoSalas;
            }
            catch (Exception ex)
            {
                permissaoSalas = null;
                return permissaoSalas;
                throw new Exception(ex.Message);
            }


        }

        //Consulta por id as permissoes no banco de dados
        public List<PermissaoSala> ConsultaPorId(int idPermissaoSala)
        {
            PermissaoSala permissaoSala = new PermissaoSala();
            List<PermissaoSala> permissaoSalas = new List<PermissaoSala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdPermissaoSala", idPermissaoSala);

                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PermissaoConsultaPorId");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                permissaoSalas = (from DataRow dataRowLinha in dataTableSala.Rows
                                  select new PermissaoSala
                                  {
                                      IdPermissaoSala = Convert.ToInt32(dataRowLinha["IdPermissaoSala"]),
                                      IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                                      IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"])
                                  }).ToList();

            }
            catch (Exception ex)
            {
                permissaoSalas = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return permissaoSalas;
        }

        //Consulta por id da sala as permissoes no banco de dados
        public List<PermissaoSala> ConsultaPorIdSala(int idSala)
        {
            PermissaoSala permissaoSala = new PermissaoSala();
            List<PermissaoSala> permissaoSalas = new List<PermissaoSala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdSala", idSala);

                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PermissaoConsultaPorIdSala");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                permissaoSalas = (from DataRow dataRowLinha in dataTableSala.Rows
                                  select new PermissaoSala
                                  {
                                      IdPermissaoSala = Convert.ToInt32(dataRowLinha["IdPermissaoSala"]),
                                      IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                                      IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"])
                                  }).ToList();


            }
            catch (Exception ex)
            {
                permissaoSalas = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return permissaoSalas;
        }

        //Consulta por id do usuario as permissoes no banco de dados
        public List<PermissaoSala> ConsultaPorIdUsuario(int idUsuario)
        {
            PermissaoSala permissaoSala = new PermissaoSala();
            List<PermissaoSala> permissaoSalas = new List<PermissaoSala>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", idUsuario);

                //Cria uma tabela com os dados do banco
                DataTable dataTableSala = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "PermissaoConsultaPorIdUsuario");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                permissaoSalas = (from DataRow dataRowLinha in dataTableSala.Rows
                                  select new PermissaoSala
                                  {
                                      IdPermissaoSala = Convert.ToInt32(dataRowLinha["IdPermissaoSala"]),
                                      IdSala = Convert.ToInt32(dataRowLinha["IdSala"]),
                                      IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"])
                                  }).ToList();

            }
            catch (Exception ex)
            {
                permissaoSalas = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return permissaoSalas;
        }

    }
}

