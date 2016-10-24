using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PermissaoSala
    {
        private int idPermissaoSala;
        private int idSala;
        private int idUsuario;

        //Método Construtor
        public PermissaoSala() { }
        public PermissaoSala(int idSala, int idUsuario)
        {

            this.idSala = idSala;
            this.idUsuario = idUsuario;
        }

        #region Atributos da Classe
        public int IdPermissaoSala
        {
            get { return this.idPermissaoSala; }
            set { this.idPermissaoSala = value; }
        }
        public int IdSala
        {
            get { return this.idSala; }
            set { this.idSala = value; }
        }

        public int IdUsuario
        {
            get { return this.idUsuario; }
            set { this.idUsuario = value; }
        }

        #endregion
    }
}
