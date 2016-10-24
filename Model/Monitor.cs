using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Monitor
    {
        private int idMonitor;
        private int idUsuario;
        private String nome;
        private String sobrenome;
        private String departamento;
        private String sala;
        private String identificacao;
        private DateTime horaEntrada;

        //Método Construtor
        public Monitor()
        {

        }
        public Monitor(int idUsuario, String nome, String sobrenome, String departamento, String sala, String identificacao, DateTime horaEntrada)
        {
            this.idUsuario = idUsuario;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.departamento = departamento;
            this.sala = sala;
            this.identificacao = identificacao;
            this.horaEntrada = horaEntrada;
        }


        #region Atributos da Classe
        public int IdMonitor
        {
            get { return this.idMonitor; }
            set { this.idMonitor = value; }
        }

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
        #endregion
    }
}
