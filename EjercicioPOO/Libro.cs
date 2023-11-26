﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    internal class Libro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public bool Prestado { get; set; }

        public void Prestar()
        {
            this.Prestado = true;
        }
        public void Devolver()
        {
            this. Prestado = false;
        }
        public string DarDatos()
        {
            return $"\t Titulo: {this.Titulo}  \t\nAutor: {this.Autor} \t\nDescripcion: {this.Descripcion} ";
        }
    }
}
