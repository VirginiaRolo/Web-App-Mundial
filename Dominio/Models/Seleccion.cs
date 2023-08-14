using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Dominio.Models
{
    public class Seleccion : IValidacion, IComparable<Seleccion>
    {
        #region Properties
        public Pais Pais { get; set; }
        public List<Jugador> Jugadores { get; set; }
        #endregion

        #region Constructores
        public Seleccion()
        {

        }

        public Seleccion(Pais pais)
        {
            Pais = pais;
            Jugadores = new List<Jugador>();
        }
        #endregion

        #region Métodos

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Seleccion seleccion &&
                   EqualityComparer<Pais>.Default.Equals(Pais, seleccion.Pais);
        }

        public override string ToString()
        {
            return $"El país es {Pais.Nombre}. Los jugadores son {JugadoresSeleccion()} ";
        }
        #endregion

        #region Métodos Clásicos
        public void EsValido()
        {
            if (Pais == null)
            {
                throw new Exception("País vacío");
            }
            if (Jugadores.Count < 11)
            {
                throw new Exception("Debe ingresar 11 jugadores");
            }
        }

        public int CompareTo([AllowNull] Seleccion other)
        {
            if (Pais.Nombre.CompareTo(other.Pais.Nombre) > 0)
            {
                return 1;
            }
            else if (Pais.Nombre.CompareTo(other.Pais.Nombre) < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool AgregarJugador(Jugador j)
        {
            if (j != null)
            {
                Jugadores.Add(j);
                return true;
            }
            return false;
        }

        public string JugadoresSeleccion()
        {
            string jugadoresSeleccion = "";

            foreach (Jugador j in Jugadores)
            {
                jugadoresSeleccion += $"{j.NombreCompleto} ";

            }
            return jugadoresSeleccion;
        }

        public List<Jugador> GetJugadoresDeSeleccion()
        {
            return Jugadores;
        }
        #endregion

        #endregion
    }
}
