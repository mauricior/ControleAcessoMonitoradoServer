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
    public class UsuarioController
    {
        AcessoDadosSqlServer acessoDadosSqlServer = AcessoDadosSqlServer.Instance;

        public string Inserir(Usuario usuario)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", usuario.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Sobrenome", usuario.Sobrenome);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", usuario.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@RG", usuario.RG);
                acessoDadosSqlServer.AdicionarParametros("@CPF", usuario.CPF);
                acessoDadosSqlServer.AdicionarParametros("@Telefone", usuario.Telefone);
                acessoDadosSqlServer.AdicionarParametros("@Celular", usuario.Celular);
                acessoDadosSqlServer.AdicionarParametros("@Email", usuario.Email);
                acessoDadosSqlServer.AdicionarParametros("@Departamento", usuario.Departamento);
                acessoDadosSqlServer.AdicionarParametros("@TAG", usuario.TAG);
                acessoDadosSqlServer.AdicionarParametros("@Senha", usuario.Senha);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "UsuarioInserir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
                return retorno;
            }

            return retorno;
        }

        public string Alterar(Usuario usuario)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", usuario.IdUsuario);
                acessoDadosSqlServer.AdicionarParametros("@Nome", usuario.Nome);
                acessoDadosSqlServer.AdicionarParametros("@Sobrenome", usuario.Sobrenome);
                acessoDadosSqlServer.AdicionarParametros("@DataNascimento", usuario.DataNascimento);
                acessoDadosSqlServer.AdicionarParametros("@RG", usuario.RG);
                acessoDadosSqlServer.AdicionarParametros("@CPF", usuario.CPF);
                acessoDadosSqlServer.AdicionarParametros("@Telefone", usuario.Telefone);
                acessoDadosSqlServer.AdicionarParametros("@Celular", usuario.Celular);
                acessoDadosSqlServer.AdicionarParametros("@Email", usuario.Email);
                acessoDadosSqlServer.AdicionarParametros("@Departamento", usuario.Departamento);
                acessoDadosSqlServer.AdicionarParametros("@TAG", usuario.TAG);
                acessoDadosSqlServer.AdicionarParametros("@Senha", usuario.Senha);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "UsuarioAlterar");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
                return retorno;
            }

            return retorno;
        }

        public string Excluir(Usuario usuario)
        {
            string retorno;

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", usuario.IdUsuario);
                acessoDadosSqlServer.ExecutarManipulacao(CommandType.StoredProcedure, "UsuarioExcluir");

                retorno = "1";
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
                return retorno;
            }

            return retorno;
        }

        //Consulta por TODOS OS USUARIOS no banco de dados o Usuario
        public List<Usuario> ConsultaTodos()
        {
            Usuario usuario = new Usuario();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                acessoDadosSqlServer.LimparParametros();


                //Cria uma tabela com os dados do banco
                DataTable dataTableUsuario = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "UsuarioConsultaTodos");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                usuarios = (from DataRow dataRowLinha in dataTableUsuario.Rows
                            select new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"]),
                                Nome = Convert.ToString(dataRowLinha["Nome"]),
                                Sobrenome = Convert.ToString(dataRowLinha["Sobrenome"]),
                                DataNascimento = Convert.ToDateTime(dataRowLinha["DataNascimento"]),
                                RG = Convert.ToString(dataRowLinha["RG"]),
                                CPF = Convert.ToString(dataRowLinha["CPF"]),
                                Telefone = Convert.ToString(dataRowLinha["Telefone"]),
                                Celular = Convert.ToString(dataRowLinha["Celular"]),
                                Email = Convert.ToString(dataRowLinha["Email"]),
                                Departamento = Convert.ToString(dataRowLinha["Departamento"]),
                                TAG = Convert.ToString(dataRowLinha["TAG"]),
                                Senha = Convert.ToString(dataRowLinha["Senha"])
                            }).ToList();





                //Retorna a lista de objetos
                //return usuarios;
            }
            catch (Exception ex)
            {
                usuarios = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return usuarios;
        }

        //Consulta por Id no banco de dados o Usuario
        public List<Usuario> ConsultaPorId(int idUsuario)
        {
            Usuario usuario = new Usuario();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@IdUsuario", idUsuario);

                //Cria uma tabela com os dados do banco
                DataTable dataTableUsuario = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "UsuarioConsultaId");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                usuarios = (from DataRow dataRowLinha in dataTableUsuario.Rows
                            select new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"]),
                                Nome = Convert.ToString(dataRowLinha["Nome"]),
                                Sobrenome = Convert.ToString(dataRowLinha["Sobrenome"]),
                                DataNascimento = Convert.ToDateTime(dataRowLinha["DataNascimento"]),
                                RG = Convert.ToString(dataRowLinha["RG"]),
                                CPF = Convert.ToString(dataRowLinha["CPF"]),
                                Telefone = Convert.ToString(dataRowLinha["Telefone"]),
                                Celular = Convert.ToString(dataRowLinha["Celular"]),
                                Email = Convert.ToString(dataRowLinha["Email"]),
                                Departamento = Convert.ToString(dataRowLinha["Departamento"]),
                                TAG = Convert.ToString(dataRowLinha["TAG"]),
                                Senha = Convert.ToString(dataRowLinha["Senha"])
                            }).ToList();


            }
            catch (Exception ex)
            {
                usuarios = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return usuarios;
        }

        //Consulta por Nome no banco de dados o Usuario
        public List<Usuario> ConsultaPorNome(string nomeUsuario)
        {
            Usuario usuario = new Usuario();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@Nome", nomeUsuario);

                //Cria uma tabela com os dados do banco
                DataTable dataTableUsuario = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "UsuarioConsultaNome");

                //Percorre cada linha dessa tabela e adiciona os dados no objeto
                usuarios = (from DataRow dataRowLinha in dataTableUsuario.Rows
                            select new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"]),
                                Nome = Convert.ToString(dataRowLinha["Nome"]),
                                Sobrenome = Convert.ToString(dataRowLinha["Sobrenome"]),
                                DataNascimento = Convert.ToDateTime(dataRowLinha["DataNascimento"]),
                                RG = Convert.ToString(dataRowLinha["RG"]),
                                CPF = Convert.ToString(dataRowLinha["CPF"]),
                                Telefone = Convert.ToString(dataRowLinha["Telefone"]),
                                Celular = Convert.ToString(dataRowLinha["Celular"]),
                                Email = Convert.ToString(dataRowLinha["Email"]),
                                Departamento = Convert.ToString(dataRowLinha["Departamento"]),
                                TAG = Convert.ToString(dataRowLinha["TAG"]),
                                Senha = Convert.ToString(dataRowLinha["Senha"])
                            }).ToList();


            }
            catch (Exception ex)
            {
                usuarios = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return usuarios;
        }

        public List<Usuario> ConsultaPorTag(string tagUsuario)
        {
            Usuario usuario = new Usuario();
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                acessoDadosSqlServer.LimparParametros();
                acessoDadosSqlServer.AdicionarParametros("@TAG", tagUsuario);

                //Cria uma tabela com os dados do banco
                DataTable dataTableUsuario = acessoDadosSqlServer.ExecutarConsulta(CommandType.StoredProcedure, "UsuarioConsultaTAG");

                //Percorre cada linha dessa tabela e adiciona os dados na lista
                usuarios = (from DataRow dataRowLinha in dataTableUsuario.Rows
                            select new Usuario
                            {
                                IdUsuario = Convert.ToInt32(dataRowLinha["IdUsuario"]),
                                Nome = Convert.ToString(dataRowLinha["Nome"]),
                                Sobrenome = Convert.ToString(dataRowLinha["Sobrenome"]),
                                DataNascimento = Convert.ToDateTime(dataRowLinha["DataNascimento"]),
                                RG = Convert.ToString(dataRowLinha["RG"]),
                                CPF = Convert.ToString(dataRowLinha["CPF"]),
                                Telefone = Convert.ToString(dataRowLinha["Telefone"]),
                                Celular = Convert.ToString(dataRowLinha["Celular"]),
                                Email = Convert.ToString(dataRowLinha["Email"]),
                                Departamento = Convert.ToString(dataRowLinha["Departamento"]),
                                TAG = Convert.ToString(dataRowLinha["TAG"]),
                                Senha = Convert.ToString(dataRowLinha["Senha"])
                            }).ToList();


            }
            catch (Exception ex)
            {
                usuarios = null;
                throw new Exception(ex.Message);
            }

            //Retorna a lista de objetos
            return usuarios;
        }



    }
}

