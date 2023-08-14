using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio.Models
{
    public class Resenia : IValidacion, IComparable<Resenia>
    {
        #region Properties
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public Periodista Periodista { get; set; }
        public DateTime Fecha { get; set; }
        public Partido Partido { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        #endregion

        #region Constructores
        public Resenia()
        {
            Id = UltimoId;
            UltimoId++;
            Fecha = DateTime.Now;
        }

        public Resenia(Periodista periodista, DateTime fecha, Partido partido, string titulo, string contenido)
        {
            Id = UltimoId;
            UltimoId++;
            Periodista = periodista;
            Fecha = fecha;
            Partido = partido;
            Titulo = titulo;
            Contenido = contenido;
        }
        #endregion

        #region Métodos

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Resenia resenia &&
                   Titulo == resenia.Titulo &&
                   Contenido == resenia.Contenido;
        }
        #endregion

        #region Métodos Clásicos
        public void EsValido()
        {
            if (Titulo.Equals("") || Titulo ==  null)
            {
                throw new Exception("Título vacío");
            }
            if (Contenido.Equals("") || Contenido == null)
            {
                throw new Exception("Contenido vacío");
            }
        }

        public void AsociarResenia(Periodista p, Partido par)
        {
            Periodista = p;
            Partido = par;
        }

        public int CompareTo(Resenia other)
        {
            if (Fecha.CompareTo(other.Fecha) > 0)
            {
                return -1;
            }
            else if (Fecha.CompareTo(other.Fecha) < 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #endregion
    }
}
