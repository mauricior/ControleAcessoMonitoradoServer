using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;
using Model;

namespace Controller
{
    public class Supervisao
    {
        private string tag;
        private string identSala;
        private string senha;
        private int idUsuario;
        private int idSala;

        #region Métodos Construtores
        public Supervisao() { }
        public Supervisao(string TAG, string identSala)
        {
            this.TAG = tag;
            this.identSala = identSala;
        }
        public Supervisao(string senha)
        {
            this.senha = senha;
        }
        #endregion

        #region Atributos da classe
        public String TAG
        {
            get { return this.tag; }
            set { this.tag = value; }
        }
        public String IdentSala
        {
            get { return this.identSala; }
            set { this.identSala = value; }
        }
        public String Senha
        {
            get { return this.senha; }
            set { this.identSala = value; }
        }
        #endregion


        /* RETORNO DA CLASSE 
         * RETORNA 1 PARA ENTRADA LIBERADA
         * RETORNA 0 PARA SAÍDA REGISTRADA
        */



        //Consulta se existe Permissão de sala para o Usuario
        public int consultaPermissao(string tag, string identSala)
        {
            this.tag = tag;
            this.identSala = identSala;

            try
            {

                idUsuario = retornaIdUsuario(tag);
                idSala = retornaIdSala(identSala);

                if (retornaPermissao(idUsuario, idSala) == 1)
                {
                    return 1;
                }

                return 0;

            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        //Verifica a senha do usuario
        public int verificaSenha(string senhaUsuario)
        {

            try
            {
                UsuarioController usuarioController = new UsuarioController();
                List<Usuario> usuarios = usuarioController.ConsultaPorId(idUsuario);

                Usuario usuario = new Usuario();
                usuario = usuarios.Find(x => x.Senha == senhaUsuario);

                if (usuario.IdUsuario == idUsuario)
                {

                    return gerenciaMonitor();

                }
                else
                    return 0;
            }
            //Caso não exista usuário ocorre uma NullReferenceExeception e retorna 0
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        //Método que consulta usuário pela tag e retorna seu id
        private int retornaIdUsuario(string tag)
        {
            //Tenta encontrar Usuario com a tag, caso nao encontre entra em NullReferenceException
            try
            {
                UsuarioController usuarioController = new UsuarioController();
                List<Usuario> usuariosTag = usuarioController.ConsultaPorTag(tag);

                //Console.WriteLine("Entrou");

                //Funciona, retorna id do usuário dono da tag
                Usuario usuario = new Usuario();
                usuario = usuariosTag.Find(x => x.TAG == tag);


                //Console.WriteLine("IdUsuario: " + usuario.IdUsuario);

                return usuario.IdUsuario;
            }

            //Se cair em NullReferenceException retorna 0
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        //Método que consulta sala pela identificação e retorna seu id
        private int retornaIdSala(string identSala)
        {
            //Tenta encontrar Sala com a identSala, caso nao encontre entra em NullReferenceException
            try
            {
                SalaController salaController = new SalaController();

                List<Sala> salasIdentificacao = salaController.ConsultaPorIdentificacao(identSala);

                Sala sala = new Sala();
                sala = salasIdentificacao.Find(x => x.Identificacao == identSala);

                return sala.IdSala;
            }
            // Se cair em NullReferenceException retorna 0
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        //Verifica se o Usuario possui permissão na sala e retorna 1 para sim e 0 para não
        private int retornaPermissao(int idUsuario, int idSala)
        {
            PermissaoSalaController permissaoSalaController = new PermissaoSalaController();

            List<PermissaoSala> permissoes = permissaoSalaController.ConsultaPorIdUsuario(idUsuario);

            PermissaoSala permissaoSala = new PermissaoSala();
            permissaoSala = permissoes.Find(x => x.IdSala == idSala);


            if (permissaoSala.IdUsuario == idUsuario)
            {
                return 1;
            }

            return 0;
        }

        //Verifica na tabela Monitor se o Usuário está presente, caso Sim exclui e passa os dados para a tabela Relátorios, caso Não adiciona os dados do Usuário e a Sala na tblMonitor
        private int gerenciaMonitor()
        {
            MonitorController monitorController = new MonitorController();
            UsuarioController usuarioController = new UsuarioController();
            SalaController salaController = new SalaController();
            List<Monitor> monitores = monitorController.ConsultaTudo();
            RelatorioController relatorioController = new RelatorioController();

            try
            {

                Monitor monitor = new Monitor();
                monitor = monitores.Find(x => x.IdUsuario == idUsuario);

                List<Usuario> usuarios = usuarioController.ConsultaPorId(idUsuario);
                Usuario usuario = usuarios.Find(x => x.IdUsuario == idUsuario);

                List<Sala> salas = salaController.ConsultaPorIdentificacao(identSala);
                Sala sala = salas.Find(x => x.Identificacao == identSala);

                if (monitor == null)
                {

                    monitor = new Monitor();
                    monitor.IdUsuario = usuario.IdUsuario;
                    monitor.Nome = usuario.Nome;
                    monitor.Sobrenome = usuario.Sobrenome;
                    monitor.Departamento = usuario.Departamento;
                    monitor.Identificacao = sala.Identificacao;
                    monitor.Sala = sala.Tipo;
                    monitor.HoraEntrada = DateTime.Now;


                    monitorController.Inserir(monitor);
                    return 1;
                }
                else
                {
                    Relatorio relatorio = new Relatorio(monitor.Nome, monitor.Sobrenome, usuario.RG, usuario.CPF, usuario.Departamento, sala.Tipo, sala.Identificacao, monitor.HoraEntrada, DateTime.Now);
                    relatorioController.Inserir(relatorio);
                    monitorController.Excluir(monitor);
                    return 0;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }



    }
}


