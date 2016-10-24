using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        private int idUsuario;
        private String nome;
        private String sobrenome;
        private DateTime dataNascimento;
        private String rg;
        private String cpf;
        private String telefone;
        private String celular;
        private String email;
        private String departamento;
        private String tag;
        private String senha;



        #region Atributos da Classe
        public int IdUsuario
        {
            get { return this.idUsuario; }
            set { this.idUsuario = value; }
        }

        public String Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }

        public String Sobrenome
        {
            get { return this.sobrenome; }
            set { this.sobrenome = value; }
        }

        public DateTime DataNascimento
        {
            get { return this.dataNascimento; }
            set { this.dataNascimento = value; }
        }

        public String RG
        {
            get { return this.rg; }
            set { this.rg = value; }
        }

        public String CPF
        {
            get { return this.cpf; }
            set { this.cpf = value; }
        }

        public String Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value; }
        }
        public String Celular
        {
            get { return this.celular; }
            set { this.celular = value; }
        }
        public String Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public String Departamento
        {
            get { return this.departamento; }
            set { this.departamento = value; }
        }
        public String TAG
        {
            get { return this.tag; }
            set { this.tag = value; }
        }
        public String Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }
        #endregion

        //Método Construtor
        public Usuario()
        {

        }
        public Usuario(String nome, String sobrenome, DateTime dataNascimento, String rg, String cpf, String telefone, String celular,
            String email, String departamento, String tag, String senha)
        {

            this.nome = nome;
            this.sobrenome = nome;
            this.dataNascimento = dataNascimento;
            this.rg = rg;
            this.cpf = cpf;
            this.telefone = telefone;
            this.celular = celular;
            this.email = email;
            this.departamento = departamento;
            this.tag = tag;
            this.senha = senha;
        }
    }
}
