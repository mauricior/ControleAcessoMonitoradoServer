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
    public class MonitorController
    {
        AcessoDadosSqlServer acessoDadosSqlServer = new AcessoDadosSqlServer();

        public string Inserir(Monitor monitor)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", monitor.IdUsuario);
                acessoDadosSqlServer.AdicionarParametros("@Nome", monitor.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Sobrenome", monitor.Sobrenome);
                acessoDadosSqlServer.AdicionarParametros("@Departamento", monitor.Departamento);
                acessoDadosSqlServer.AdicionarParametros("@Sala", monitor.Sala);
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", monitor.Identificacao);
                acessoDadosSqlServer.AdicionarParametros("@HoraEntrada", monitor.HoraEntrada);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "MonitorInserir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public string Alterar(Monitor monitor)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdMonitor", monitor.IdMonitor);
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", monitor.IdUsuario);
                acessoDadosSqlServer.AdicionarParametros("@Nome", monitor.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Sobrenome", monitor.Sobrenome);
                acessoDadosSqlServer.AdicionarParametros("@Departamento", monitor.Departamento);
                acessoDadosSqlServer.AdicionarParametros("@Sala", monitor.Sala);
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", monitor.Identificacao);
                acessoDadosSqlServer.AdicionarParametros("@HoraEntrada", monitor.HoraEntrada);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "MonitorAlterar");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        public string Excluir(Monitor monitor)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdMonitor", monitor.IdMonitor);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "MonitorExcluir");


                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }


        //Consulta TUDO da tabela MONITOR no banco de dados
        public List<Monitor> ConsultaTudo()
        {
            Monitor monitor = new Monitor();
            List<Monitor> monitores = new List<Monitor>();

            try
            {
                acessoDadosSqlServer.LimparParametros();

                //Cria uma tabela com os dados do banco
                DataTable dataTableMonitor = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "MonitorConsultaTudo");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                monitores = (from DataRow dataRowLinha in dataTableMonitor.Rows
                             select new Monitor
                             {
                                 IdMonitor = Convert.ToInt32(dataRowLinha["IdMonitor"]),
                                 IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"]),
                                 Nome = Convert.ToString(dataRowLinha["Nome"]),
                                 Sobrenome = Convert.ToString(dataRowLinha["Sobrenome"]),
                                 Departamento = Convert.ToString(dataRowLinha["Departamento"]),
                                 Sala = Convert.ToString(dataRowLinha["Sala"]),
                                 Identificacao = Convert.ToString(dataRowLinha["Identificacao"]),
                                 HoraEntrada = Convert.ToDateTime(dataRowLinha["HoraEntrada"])
                             }).ToList();


                //Retorna a lista de objetos
                return monitores;
            }
            catch (Exception ex)
            {
                monitores = null;
                throw new Exception(ex.Message);
            }

        }

    }
}

