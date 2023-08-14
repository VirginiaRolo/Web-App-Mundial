using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Periodista : Funcionario, IComparable<Periodista>
    {
        #region Properties
        //hereda todo
        #endregion

        #region Constructores
        public Periodista() : base()
        {

        }

        public Periodista(string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {

        }
        #endregion

        #region Métodos

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Periodista periodista &&
                   Email == periodista.Email;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, apellido {Apellido}, email: {Email}";
        }

        public override void EsValido()
        {
            if (Nombre.Equals(""))
            {
                throw new Exception("Nombre vacío");
            }
            if (Apellido == "")
            {
                throw new Exception("Apellido vacío");
            }
            if (Email.Equals(""))
            {
                throw new Exception("Email vacío");
            }
            if (!Email.Contains("@") || Email.IndexOf('@') == 0 || Email.IndexOf('@') == Email.Length - 1)
            {
                throw new Exception("El email debe contener @, y no puede ser el primer ni último caracter");
            }
            if (Password.Length < 8)
            {
                throw new Exception("La contraseña debe tener al menos 8 caracteres");
            }
        }

        public override string GetRol()
        {
            return "PER";
        }
        #endregion

        #region Métodos Clásicos
        public int CompareTo(Periodista other)
        {
            if (Apellido.CompareTo(other.Apellido) > 0)
            {
                return 1;
            }
            else if (Apellido.CompareTo(other.Apellido) < 0)
            {
                return -1;
            }
            else
            {
                if (Nombre.CompareTo(other.Nombre) > 0)
                {
                    return 1;
                }
                else if (Nombre.CompareTo(other.Nombre) < 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

        }
        #endregion

        #endregion
    }
}
