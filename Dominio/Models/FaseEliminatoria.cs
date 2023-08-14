using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class FaseEliminatoria : Partido
    {
        #region Properties
        public bool HuboAlargue { get; set; }
        public bool HuboPenales { get; set; }
        public TipoEtapa Etapa { get; set; }
        #endregion

        #region Constructores
        public FaseEliminatoria() : base()
        {

        }

        public FaseEliminatoria(DateTime fecha, bool huboAlargue, bool huboPenales, TipoEtapa etapa) : base(fecha)
        {
            HuboAlargue = huboAlargue;
            HuboPenales = huboPenales;
            Etapa = etapa;
        }
        #endregion

        #region Métodos

        #region Métodos Override
        public override string ResultadoPartido()
        {
            string resultado = "";

            if (Finalizado)
            {
                Seleccion a = SeleccionesEnfrentadas[0];
                Seleccion b = SeleccionesEnfrentadas[1];

                int contadorA = 0;
                int contadorB = 0;

                int contadorPenalesA = 0;
                int contadorPenalesB = 0;

                foreach (Incidencia inci in Incidencias)
                {
                    if (inci.TipoIncidencia == TipoDeIncidencia.golConvertido && inci.MinutoOcurrido != -1 && inci.Jugador.Pais == a.Pais)
                    {
                        contadorA++;
                    }
                    else
                    {
                        contadorB++;
                    }

                    if (HuboPenales && inci.Jugador.Pais == a.Pais)
                    {
                        contadorPenalesA++;
                    }
                    else
                    {
                        contadorPenalesB++;
                    }
                }

                if (contadorA > contadorB)
                {
                    if (HuboAlargue)
                    {
                        resultado = $"Ganador: {a.Pais.Nombre} en alargue.";
                    }
                    else
                    {
                        resultado = $"Ganador: {a.Pais.Nombre}";
                    }
                }
                else if (contadorB > contadorA)
                {
                    if (HuboAlargue)
                    {
                        resultado = $"Ganador: {b.Pais.Nombre} en alargue.";
                    }
                    else
                    {
                        resultado = $"Ganador: {b.Pais.Nombre}";
                    }
                }
                else if (contadorPenalesA > contadorPenalesB)
                {
                    resultado = $"Empate en tiempo de juego. Ganador: {a.Pais.Nombre} en tanda de penales.";
                }
                else
                {
                    resultado = $"Empate en tiempo de juego. Ganador: {b.Pais.Nombre} en tanda de penales.";
                }
            }
            return resultado;
        }

        public override string InfoPartido()
        {
            int golesSelA = CantidadGolesPorSeleccionA();
            int golesSelB = CantidadGolesPorSeleccionB();

            int amarillasSelA = CantidadAmarillasPorSeleccionA();
            int amarillasSelB = CantidadAmarillasPorSeleccionB();

            int rojasSelA = CantidadRojasPorSeleccionA();
            int rojasSelB = CantidadRojasPorSeleccionB();


            return $"Fase: Fase Eliminatoria Fecha: {Fecha}. Etapa: {Etapa} " +
                $"Selección 1: {SeleccionesEnfrentadas[0].Pais.Nombre} " +
                $"cantidad de goles: {golesSelA}, " +
                $"cantidad de amarillas: {amarillasSelA}, " +
                $"cantidad de rojas: {rojasSelA}, " +
                $"Información sobre incidencias: {InfoIncidenciasSelA()} " +

                $"Selección 2: {SeleccionesEnfrentadas[1].Pais.Nombre} " +
                $"cantidad de goles: {golesSelB}, " +
                $"cantidad de amarillas: {amarillasSelB}, " +
                $"cantidad de rojas: {rojasSelB}, " +
                $"Información sobre incidencias: {InfoIncidenciasSelB()} " +

                $"Resultado: {Resultado}";
        }

        public override void EsValido()
        {
            if (SeleccionesEnfrentadas.Count < 2 || SeleccionesEnfrentadas.Count > 2)
            {
                throw new Exception("Debe ingresar dos selecciones");
            }
            if (Fecha < new DateTime(2022, 11, 20, 00, 00, 00))
            {
                throw new Exception("La fecha del partido debe posterior al 20/11/2022");
            }
            if (Fecha > new DateTime(2022, 12, 18, 23, 59, 59))
            {
                throw new Exception("La fecha del partido debe ser antes del 18/12/2022");
            }
        }

        public override bool Equals(object obj)
        {
            return obj is FaseEliminatoria eliminatoria &&
                   base.Equals(obj) &&
                   EqualityComparer<List<Seleccion>>.Default.Equals(SeleccionesEnfrentadas, eliminatoria.SeleccionesEnfrentadas) &&
                   Fecha == eliminatoria.Fecha;
        }

        public override string ToString()
        {
            return $"Fecha: {Fecha}, resultado: {Resultado}, selecciones enfrentadas:  " +
                $"{MostrarSeleccionesEnfrentadas()} , cantidad de incidencias: {MostrarCantidadIncidencias()}," +
                $"etapa {Etapa}";
        }

        #endregion

        #region Métodos Clásicos
        public string InfoIncidenciasSelA()
        {
            Seleccion a = SeleccionesEnfrentadas[0];

            string infoInciA = "";

            foreach (Incidencia i in Incidencias)
            {
                if (i.TipoIncidencia == TipoDeIncidencia.golConvertido && i.Jugador.Pais == a.Pais)
                {
                    infoInciA += $"minuto: {i.MinutoOcurrido}, jugador: {i.Jugador.NombreCompleto} ";
                }
            }
            return infoInciA;
        }

        public string InfoIncidenciasSelB()
        {
            Seleccion b = SeleccionesEnfrentadas[1];

            string infoInciB = "";

            foreach (Incidencia i in Incidencias)
            {
                if (i.TipoIncidencia == TipoDeIncidencia.golConvertido && i.Jugador.Pais == b.Pais)
                {
                    infoInciB += $"minuto: {i.MinutoOcurrido}, jugador: {i.Jugador.NombreCompleto} ";
                }
            }
            return infoInciB;
        }
        #endregion

        #endregion
    }
}
