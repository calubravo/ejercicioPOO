using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    internal class Interfaz
    {
        static Interfaz()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine("\t\t*           Gestión de Biblioteca          *");
            Console.WriteLine("\t\t********************************************");
            Console.WriteLine("\t\t\n[A] Registrar un estudiante.");
            Console.WriteLine("\t\t\n[B] Prestar un libro a un estudiante.");
            Console.WriteLine("\t\t\n[C] Devolver libro.");
            Console.WriteLine("\t\t\n[D] Listar todos los libros.");
            Console.WriteLine("\t\t\n[E] Consultar por los libros que tiene prestados un estudiante.");
            Console.WriteLine("\t\t\n[S] Salir de la aplicación.");
            Console.WriteLine("\t\t\n******************************************");
            return Interfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("\n[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
