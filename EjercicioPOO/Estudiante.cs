using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    internal class Estudiante
    {


        public uint Legajo { get; set; }
        public List<string> Libros { get; set; }
        public Estudiante()
        {
            Libros = new List<string>();
        }
        public string DarDatos()
        {
            string ListaLibros = "";

            if (Libros.Count > 0)
            {
                foreach (var libro in Libros)
                {
                    ListaLibros += $"{libro}\n";
                }
            }
            else
            {
                ListaLibros = "El estudiente no cuenta con libros";
            }


            return $"Legajo: {this.Legajo} - Lista de libros: {ListaLibros}";
        }
    }
}
