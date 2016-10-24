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
    public class RelatorioController
    {
        AcessoDadosSqlServer acessoDadosSqlServer = AcessoDadosSqlServer.Instance;

        public string Inserir(Relatorio relatorio)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", relatorio.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Sobrenome", relatorio.Sobrenome);
                acessoDadosSqlServer.AdicionarParametros("@RG", relatorio.RG);
                acessoDadosSqlServer.AdicionarParametros("@CPF", relatorio.CPF);
                acessoDadosSqlServer.AdicionarParametros("@Departamento", relatorio.Departamento);
                acessoDadosSqlServer.AdicionarParametros("@Sala", relatorio.Sala);
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", relatorio.Identificacao);
                acessoDadosSqlServer.AdicionarParametros("@HoraEntrada", relatorio.HoraEntrada);
                acessoDadosSqlServer.AdicionarParametros("@HoraSaida", relatorio.HoraSaida);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "RelatorioInserir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                retorno = "0";
                //return retorno;
            }

            return retorno;
        }

        public string Alterar(Relatorio relatorio)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdRelatorio", relatorio.IdRelatorio);
                acessoDadosSqlServer.AdicionarParametros("@Nome", relatorio.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Sobrenome", relatorio.Sobrenome);
                acessoDadosSqlServer.AdicionarParametros("@RG", relatorio.RG);
                acessoDadosSqlServer.AdicionarParametros("@CPF", relatorio.CPF);
                acessoDadosSqlServer.AdicionarParametros("@Departamento", relatorio.Departamento);
                acessoDadosSqlServer.AdicionarParametros("@Sala", relatorio.Sala);
                acessoDadosSqlServer.AdicionarParametros("@Identificacao", relatorio.Identificacao);
                acessoDadosSqlServer.AdicionarParametros("@HoraEntrada", relatorio.HoraEntrada);
                acessoDadosSqlServer.AdicionarParametros("@HoraSaida", relatorio.HoraSaida);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "RelatorioAlterar");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
                return retorno;
            }

            return retorno;
        }

        public string Excluir(Relatorio relatorio)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdRelatorio", relatorio.IdRelatorio);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "RelatorioExcluir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
                return retorno;
            }

            return retorno;
        }

        public List<Relatorio> ConsultaTodos()
        {
            Relatorio relatorio = new Relatorio();
            List<Relatorio> relatorios = new List<Relatorio>();

            try
            {
                acessoDadosSqlServer.LimparParametros();


                //Cria uma tabela com os dados do banco
                DataTable dataTableRelatorio = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "RelatorioConsultaTudo");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                relatorios = (from DataRow dataRowLinha in dataTableRelatorio.Rows
                              select new Relatorio
                              {
                                  IdRelatorio = Convert.ToInt32(dataRowLinha["IdRelatorio"]),
                                  Nome = Convert.ToString(dataRowLinha["Nome"]),
                                  Sobrenome = Convert.ToString(dataRowLinha["Sobrenome"]),
                                  RG = Convert.ToString(dataRowLinha["RG"]),
                                  CPF = Convert.ToString(dataRowLinha["CPF"]),
                                  Departamento = Convert.ToString(dataRowLinha["Departamento"]),
                                  Sala = Convert.ToString(dataRowLinha["Sala"]),
                                  Identificacao = Convert.ToString(dataRowLinha["Identificacao"]),
                                  HoraEntrada = Convert.ToDateTime(dataRowLinha["HoraEntrada"]),
                                  HoraSaida = Convert.ToDateTime(dataRowLinha["HoraSaida"])
                              }).ToList();





                //Retorna a lista de objetos
                return relatorios;
            }
            catch (Exception ex)
            {
                relatorios = null;
                return relatorios;
                throw new Exception(ex.Message);
            }


        }

    }
}

