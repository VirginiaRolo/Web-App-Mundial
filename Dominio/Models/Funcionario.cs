using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public abstract class Funcionario : IValidacion
    {
        #region Properties
        public static int UltimoId { get; set; } = 1;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructores
        public Funcionario()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Funcionario(string nombre, string apellido, string email, string password)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }
        #endregion

        #region Métodos

        #region Métodos Abstractos
        public abstract void EsValido();

        public abstract string GetRol();
        #endregion

        #endregion

    }
}
