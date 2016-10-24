using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Relatorio
    {
        private int idRelatorio;
        private String nome;
        private String sobrenome;
        private String rg;
        private String cpf;
        private String departamento;
        private String sala;
        private String identificacao;
        private DateTime horaEntrada;
        private DateTime horaSaida;

        #region Atributos da classe
        public int IdRelatorio
        {
            get { return this.idRelatorio; }
            set { this.idRelatorio = value; }
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

        public String Departamento
        {
            get { return this.departamento; }
            set { this.departamento = value; }
        }

        public String Sala
        {
            get { return this.sala; }
            set { this.sala = value; }
        }

        public String Identificacao
        {
            get { return this.identificacao; }
            set { this.identificacao = value; }
        }

        public DateTime HoraEntrada
        {
            get { return this.horaEntrada; }
            set { this.horaEntrada = value; }
        }

        public DateTime HoraSaida
        {
            get { return this.horaSaida; }
            set { this.horaSaida = value; }
        }


        #endregion


        //Método Construtor
        public Relatorio() { }
        public Relatorio(String nome, String sobrenome, String rg, String cpf, String departamento, String sala, String identificacao, DateTime horaEntrada, DateTime horaSaida)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.rg = rg;
            this.cpf = cpf;
            this.departamento = departamento;
            this.sala = sala;
            this.identificacao = identificacao;
            this.horaEntrada = horaEntrada;
            this.horaSaida = horaSaida;
        }
    }
}
