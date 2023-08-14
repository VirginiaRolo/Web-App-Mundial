using Dominio;
using Dominio.Models;
using System;

namespace Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            Sistema s = Sistema.GetInstancia();

            int op = -1;

            while (op != 0)
            {
                Console.Clear();
                Console.WriteLine("1 - Dar de Alta un periodista");
                Console.WriteLine("2 - Asignar el valor de referencia para la categoría financiera de los jugadores");
                Console.WriteLine("3 - Dado el id de un jugador listar todos los partidos en los que haya participado");
                Console.WriteLine("4 - Listar todos los jugadores que han sido expulsados al menos una vez");
                Console.WriteLine("5 - Dado el nombre de una selección obtener el partido con más cantidad de goles en que haya participado");
                Console.WriteLine("6 - Listar todos los jugadores que hayan convertido al menos 1 gol en un partido,");
                Console.WriteLine("0 - Salir");

                op = Int32.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del periodista");
                        string nombrePeriodista = Console.ReadLine();
                        Console.WriteLine("Ingrese el apellido del periodista");
                        string apellidoPeriodista = Console.ReadLine();
                        Console.WriteLine("Ingrese el email del periodista");
                        string emailPeriodista = Console.ReadLine();
                        Console.WriteLine("Ingrese una contraseña para el periodista");
                        string passPeriodista = Console.ReadLine();

                        Periodista nuevoPeriodista = new Periodista(nombrePeriodista, apellidoPeriodista, emailPeriodista, passPeriodista);

                        try
                        {
                            s.AltaFuncionario(nuevoPeriodista);
                            Console.WriteLine("Alta exitosa");
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);

                        }
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el valor de referencia para la categoría financiera de los jugadores");
                        double valorRef = Double.Parse(Console.ReadLine());

                        Console.WriteLine($"{s.GetMontoJ()} - Valor anterior");
                        try
                        {
                            s.AsignarValor(valorRef);

                            if (s.GetMontoJ() == valorRef)
                            {
                                Console.WriteLine($"{s.GetMontoJ()} - Se cambió el valor");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        s.CategoriaFinanciera(valorRef);
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el id del jugador");
                        int idJugador = Int32.Parse(Console.ReadLine());

                        foreach (Partido p in s.MostrarPartidosDeJugador(idJugador))
                        {
                            Console.WriteLine(s.DatosPartido());
                        }
                        break;
                    case 4:

                        foreach (Jugador jug in s.MostrarJugadoresExpulsados())
                        {

                            Console.WriteLine($"Valor: {jug.Valor}, Nombre: {jug.NombreCompleto}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Ingrese una selección");
                        string nombreSeleccion = Console.ReadLine();

                        foreach (Partido part in s.PartidosConMasGoles(nombreSeleccion))
                        {

                            Console.WriteLine(part.MostrarSeleccionesEnfrentadas());
                        }
                        break;
                    case 6:
                        foreach (Jugador j in s.MostrarJugadoresConGoles())
                        {

                            Console.WriteLine($"Nombre: {j.NombreCompleto}, Valor: {j.Valor} {j.Moneda}, Categoría financiera: {j.CatFinanciera}");
                        }
                        break;



                }

                //Console.WriteLine(FaseDeGrupos.ResultadoPartido( pfg1));

                Console.ReadKey();
            }
        }
    }
}
