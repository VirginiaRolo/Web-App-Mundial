using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class Incidencia : IValidacion
    {
        #region Properties
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public TipoDeIncidencia TipoIncidencia { get; set; }
        public int MinutoOcurrido { get; set; }
        public Jugador Jugador { get; set; }
        #endregion

        #region Constructores
        public Incidencia()
        {
            Id = UltimoId;
            UltimoId++;
        }

        public Incidencia(TipoDeIncidencia tipoIncidencia, int minutoOcurrido, Jugador jugador)
        {
            Id = UltimoId;
            UltimoId++;
            TipoIncidencia = tipoIncidencia;
            MinutoOcurrido = minutoOcurrido;
            Jugador = jugador;
        }
        #endregion

        #region Métodos
        #region Métodos Clásicos
        public void EsValido()
        {
            if (MinutoOcurrido < -1)
            {
                throw new Exception("El minuto debe ser un valor mayor a 0 o igual a -1");
            }
            if (Jugador == null)
            {
                throw new Exception("Jugador vacío");
            }
        }
        #endregion

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Incidencia incidencia &&
                   Id == incidencia.Id;
        }

        public override string ToString()
        {
            return $"Tipo de incidencia {TipoIncidencia}, minuto {MinutoOcurrido}, jugador{Jugador.NombreCompleto} ";
        }
        #endregion

        #endregion
    }
}
