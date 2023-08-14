using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio.Models
{
    public class Jugador : IValidacion, IComparable<Jugador>
    {
        #region Properties
        public int Id { get; set; }
        public string NumeroCamiseta { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FNac { get; set; }
        public double Altura { get; set; }
        public string PieHabil { get; set; }
        public double Valor { get; set; }
        public string Moneda { get; set; }
        public Pais Pais { get; set; }
        public string Puesto { get; set; }
        public static double Monto { get; set; }
        public string CatFinanciera { get; set; }
        #endregion

        #region Constructores
        public Jugador()
        {

        }

        public Jugador(int id, string numeroCamiseta, string nombreCompleto, DateTime fNac, double altura, string pieHabil, double valor, string moneda, Pais pais, string puesto)
        {
            Id = id;
            NumeroCamiseta = numeroCamiseta;
            NombreCompleto = nombreCompleto;
            FNac = fNac;
            Altura = altura;
            PieHabil = pieHabil;
            Valor = valor;
            Moneda = moneda;
            Pais = pais;
            Puesto = puesto;
            CatFinanciera = "Estándar";
            Monto = 100;
        }
        #endregion

        #region Metodos

        #region Métodos Override
        public override bool Equals(object obj)
        {
            return obj is Jugador jugador &&
                   Id == jugador.Id;
        }

        public override string ToString()
        {
            return $"Nombre: {NombreCompleto}, número de camisera{NumeroCamiseta}, fecha de nacimiento: {FNac}, altura:{Altura}, " +
                $"pie hábil{PieHabil}, valor de mercado: {Valor} {Moneda}, país: {Pais.Nombre}, puesto: {Puesto}, " +
                $"categoría financiera: {CatFinanciera}";
        }
        #endregion

        #region Métodos Clásicos
        public void EsValido()
        {
            if (NombreCompleto.Equals(""))
            {
                throw new Exception("Nombre vacío");
            }
            if (NumeroCamiseta.Equals(""))
            {
                throw new Exception("Número de camiseta vacío");
            }
            if (PieHabil.Equals(""))
            {
                throw new Exception("Pie hábil vacío");
            }
            if (Valor < 0)
            {
                throw new Exception("El valor de mercado no puede ser menor a 0");
            }
            if (Moneda.Equals(""))
            {
                throw new Exception("Moneda vacía");
            }
            if (Puesto.Equals(""))
            {
                throw new Exception("Puesto vacío");
            }
            if (Pais == null)
            {
                throw new Exception("País vacío");
            }

        }

        //Definimos el criterio de ordenación para la lista de jugadores, ordenada primero por valor de mercado.
        //si hubiera dos jugadores con el mismo valor de mercado, desempata por nombre 
        public int CompareTo([AllowNull] Jugador other)
        {
            if (Valor.CompareTo(other.Valor) < 0)
            {
                return 1;
            }
            else if (Valor.CompareTo(other.Valor) > 0)
            {
                return -1;
            }
            else
            {
                if (NombreCompleto.CompareTo(other.NombreCompleto) < 0)
                {
                    return 1;
                }
                else if (NombreCompleto.CompareTo(other.NombreCompleto) > 0)
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
