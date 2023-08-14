using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Models
{
    public class FaseDeGrupos : Partido
    {
        #region Properties
        public string NombreDelGrupo { get; set; }

        #endregion

        #region Constructores
        public FaseDeGrupos() : base()
        {

        }

        public FaseDeGrupos(DateTime fecha, string nombreGrupo) : base(fecha)
        {
            NombreDelGrupo = nombreGrupo;
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

                foreach (Incidencia inci in Incidencias)
                {
                    if (inci.TipoIncidencia == TipoDeIncidencia.golConvertido && inci.Jugador.Pais == a.Pais)
                    {
                        contadorA++;
                    }
                    else
                    {
                        contadorB++;
                    }
                }

                if (contadorA > contadorB)
                {
                    resultado = $"Ganador: {a.Pais.Nombre}";
                }
                else if (contadorB > contadorA)
                {
                    resultado = $"Ganador: {b.Pais.Nombre}";
                }
                else
                {
                    resultado = "Empate";
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

            return $"Fase: Fase de Grupos Fecha: {Fecha}. Selección 1: {SeleccionesEnfrentadas[0].Pais.Nombre} " +
                $"cantidad de goles: {golesSelA}, " +
                $"cantidad de amarillas: {amarillasSelA}, " +
                $"cantidad de rojas: {rojasSelA}, " +

                $"Selección 2: {SeleccionesEnfrentadas[1].Pais.Nombre} " +
                $"cantidad de goles: {golesSelB}, " +
                $"cantidad de amarillas: {amarillasSelB}, " +
                $"cantidad de rojas: {rojasSelB}, " +

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
            return obj is FaseDeGrupos grupos &&
                   base.Equals(obj) &&
                   EqualityComparer<List<Seleccion>>.Default.Equals(SeleccionesEnfrentadas, grupos.SeleccionesEnfrentadas) &&
                   Fecha == grupos.Fecha;
        }

        public override string ToString()
        {
            return $"Fecha: {Fecha}, resultado: {Resultado}, selecciones enfrentadas: " +
                $"{MostrarSeleccionesEnfrentadas()} , " +
                $"cantidad de incidencias: {MostrarCantidadIncidencias()}," +
                $"nombre del grupo: {NombreDelGrupo} ";
        }
        #endregion

        #endregion
    }
}
