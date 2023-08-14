using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public abstract class Partido : IValidacion
    {
        #region Properties
        private static int UltimoId { get; set; }
        public int Id { get; set; }
        public List<Seleccion> SeleccionesEnfrentadas { get; set; }
        public DateTime Fecha { get; set; }
        public bool Finalizado { get; set; }
        public List<Incidencia> Incidencias { get; set; }
        public string Resultado { get; set; }
        #endregion

        #region Constructores
        public Partido()
        {
            Id = UltimoId;
            UltimoId++;
        }

        protected Partido(DateTime fecha)
        {
            Id = UltimoId;
            UltimoId++;
            SeleccionesEnfrentadas = new List<Seleccion>();
            Fecha = fecha;
            Finalizado = false;
            Incidencias = new List<Incidencia>();
            Resultado = "Pendiente";
        }
        #endregion

        #region Métodos

        #region Métodos Abstractos
        public abstract void EsValido();
        public abstract override string ToString();
        public abstract string ResultadoPartido();
        public abstract string InfoPartido();
        #endregion

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Partido partido &&
                   EqualityComparer<List<Seleccion>>.Default.Equals(SeleccionesEnfrentadas, partido.SeleccionesEnfrentadas) &&
                   Fecha == partido.Fecha;
        }
        #endregion

        #region Métodos clásicos
        public void FinalizarPartido()
        {
            if (!Finalizado)
            {
                Finalizado = true;
                Resultado = ResultadoPartido();
            }
        }

        public bool AgregarSeleccion(Seleccion selec)
        {
            if (selec != null)
            {
                SeleccionesEnfrentadas.Add(selec);
                return true;
            }
            return false;
        }

        // ACA AGREGUE QUE EL PARTIDO NO ESTE FINALIZADO
        public bool AgregarIncidencia(Incidencia inci)
        {
            if (inci != null)
            {
                inci.EsValido();
                if (JugadorPerteneceASelec(inci.Jugador) && !Finalizado)
                {
                    Incidencias.Add(inci);
                    return true;
                }
            }
            return false;
        }
        // Verificamos que el jugador pertenezca a alguna de las selecciones enfrentadas
        private bool JugadorPerteneceASelec(Jugador j)
        {
            foreach (Seleccion sel in SeleccionesEnfrentadas)
            {
                if (sel.Pais.Nombre == j.Pais.Nombre)
                {
                    return true;
                }

            }
            return false;
        }

        public string MostrarSeleccionesEnfrentadas()
        {
            string selecEnfrentadas = "";

            if (SeleccionesEnfrentadas.Count == 2)
            {
                selecEnfrentadas += $"{SeleccionesEnfrentadas[0].Pais.Nombre} - {SeleccionesEnfrentadas[1].Pais.Nombre}";
            }
            return selecEnfrentadas;
        }

        public List<Seleccion> VerSeleccionesEnfrentadas()
        {
            return SeleccionesEnfrentadas;
        }

        public int CantidadGolesPorSeleccionA()
        {
            Seleccion a = SeleccionesEnfrentadas[0];

            int golesA = 0;

            foreach (Incidencia inci in Incidencias)
            {
                if (inci.TipoIncidencia == TipoDeIncidencia.golConvertido && inci.Jugador.Pais == a.Pais)
                {
                    golesA++;
                }
            }
            return golesA;
        }

        public int CantidadGolesPorSeleccionB()
        {
            Seleccion b = SeleccionesEnfrentadas[1];

            int golesB = 0;

            foreach (Incidencia inci in Incidencias)
            {
                if (inci.TipoIncidencia == TipoDeIncidencia.golConvertido && inci.Jugador.Pais == b.Pais)
                {
                    golesB++;
                }
            }
            return golesB;
        }

        public int CantidadAmarillasPorSeleccionA()
        {
            Seleccion a = SeleccionesEnfrentadas[0];

            int amarillasA = 0;

            foreach (Incidencia inci in Incidencias)
            {
                if (inci.TipoIncidencia == TipoDeIncidencia.amonestacion && inci.Jugador.Pais == a.Pais)
                {
                    amarillasA++;
                }
            }
            return amarillasA;
        }

        public int CantidadAmarillasPorSeleccionB()
        {
            Seleccion b = SeleccionesEnfrentadas[1];

            int amarillasB = 0;

            foreach (Incidencia inci in Incidencias)
            {
                if (inci.TipoIncidencia == TipoDeIncidencia.amonestacion && inci.Jugador.Pais == b.Pais)
                {
                    amarillasB++;
                }
            }
            return amarillasB;
        }

        public int CantidadRojasPorSeleccionA()
        {
            Seleccion a = SeleccionesEnfrentadas[0];

            int rojasA = 0;

            foreach (Incidencia inci in Incidencias)
            {
                if (inci.TipoIncidencia == TipoDeIncidencia.expulsion && inci.Jugador.Pais == a.Pais)
                {
                    rojasA++;
                }
            }
            return rojasA;
        }

        public int CantidadRojasPorSeleccionB()
        {
            Seleccion b = SeleccionesEnfrentadas[1];

            int rojasB = 0;

            foreach (Incidencia inci in Incidencias)
            {
                if (inci.TipoIncidencia == TipoDeIncidencia.expulsion && inci.Jugador.Pais == b.Pais)
                {
                    rojasB++;
                }
            }
            return rojasB;
        }

        public int MostrarCantidadIncidencias()
        {
            int incidencias = 0;

            foreach (Incidencia inci in Incidencias)
            {
                incidencias++;
            }

            return incidencias;
        }
        #endregion

        #endregion
    }
}



