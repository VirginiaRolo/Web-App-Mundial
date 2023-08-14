using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Pais : IValidacion
    {
        #region Properties
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        #endregion

        #region Constructores
        public Pais()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Pais(string nombre, string codigo)
        {
            Id = UltimoId;
            UltimoId++;
            Nombre = nombre;
            Codigo = codigo;
        }
        #endregion

        #region Métodos

        #region Métodos Clásicos
        public void EsValido()
        {
            if (Nombre.Equals(""))
            {
                throw new Exception("Nombre vacío");
            }
            if (Codigo.Equals(""))
            {
                throw new Exception("Código vacío");
            }
            if (Codigo.Length != 3)
            {
                throw new Exception("El código debe ser de 3 caracteres");
            }
        }
        #endregion

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Pais pais &&
                   Nombre == pais.Nombre;
        }

        public override string ToString()
        {
            return $"{Nombre}, código: {Codigo}";
        }
        #endregion
        
        #endregion
    }
}
