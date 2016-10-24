using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sala
    {
        private int idSala;
        private String identificacao;
        private String tipo;

        //Método Construtor
        public Sala() { }
        public Sala(String identificacao, String tipo)
        {

            this.identificacao = identificacao;
            this.tipo = tipo;
        }

        #region Atributos da Classe
        public int IdSala
        {
            get { return this.idSala; }
            set { this.idSala = value; }
        }

        public String Identificacao
        {
            get { return this.identificacao; }
            set { this.identificacao = value; }
        }

        public String Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        #endregion
    }
}
