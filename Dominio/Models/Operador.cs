using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Operador : Funcionario
    {
        #region Properties
        public DateTime FComienzo { get; set; }
        #endregion

        #region Constructores
        public Operador() : base()
        {

        }

        public Operador(string nombre, string apellido, string email, string password, DateTime fComienzo) : base(nombre, apellido, email, password)
        {
            FComienzo = fComienzo;
        }
        #endregion

        #region Métodos

        #region Métodos Override
        public override void EsValido()
        {
            if (Nombre == "")
            {
                throw new Exception("Nombre vacío");
            }
        }

        public override string GetRol()
        {
            return "OPE";
        }
        #endregion
        #endregion
    }
}
