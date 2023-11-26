using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    internal class Biblioteca
    {
        public List<Estudiante> ListaEstudiantes = new List<Estudiante>();
        public List<Libro> ListaLibros { get; set; }

        public Biblioteca()
        {
            ListaLibros = new List<Libro>();
        }

        public string ListarLibros()
        {
            string datos = "";
            int I = 0;
            foreach (var Libro in ListaLibros)
            {
                if (Libro.Prestado)
                {
                    datos += $"[{I}]{Libro.DarDatos()}\n[PRESTADO]\n\n";
                }
                else
                {
                    datos += $"[{I}]{Libro.DarDatos()}\n [EN STOCK]\n\n";
                }
                I++;
            }
            return datos;
        }
        public string ListarTitulos()
        {
            string datos = "";
            int I = 0;
            foreach (var Libro in ListaLibros)
            {
               
                datos += $"\t [{I}]-{Libro.Titulo}\n";
                I++;
            }
            return datos;

        }
        public bool LegajoUnico(uint legajo)
        {
            foreach (Estudiante estudiante in ListaEstudiantes)
            {
                if (BuscarEstudiante(legajo).Legajo == legajo)
                {
                    return false;
                }
            }
            return true;
        }
        public string RegistrarEstudiante(uint legajoEstudiante)
        {
            if (LegajoUnico(legajoEstudiante))
            {
                Estudiante estudiante = new Estudiante();
                estudiante.Legajo = legajoEstudiante;
                ListaEstudiantes.Add(estudiante);
                return "Estudiante Registrado con exito";
            }
            else
            { return "Legajo no valido"; }

        }
        public Estudiante BuscarEstudiante(uint legajo)
        {
            Estudiante EstudianteEncontrado = new Estudiante();
            foreach (Estudiante estudiante in ListaEstudiantes)
            {
                if (estudiante.Legajo == legajo)
                {

                    EstudianteEncontrado = estudiante;
                }
            }
            return EstudianteEncontrado;
        }
        public string PrestarLibro(uint legajo, int indiceLibro)
        {
            Estudiante EstudiantePrestar = new Estudiante();
            EstudiantePrestar = BuscarEstudiante(legajo);
            Libro LibroPrestar = ListaLibros[indiceLibro];
            if (LibroPrestar.Prestado)
            { return "El libro solicitado ya esta prestado"; }
            else
            {
                if (EstudiantePrestar != null)
                {
                    LibroPrestar.Prestar();
                    EstudiantePrestar.Libros.Add($"{LibroPrestar.Titulo}");
                    return $"Libro asignado correctamente a legajo {EstudiantePrestar.Legajo} ";
                }
                else
                {
                    return "El estudiante no se encuentra registrado";
                }
            }

        }
        public string DevolverLibro(uint legajo, int indiceLibro)
        {
            Estudiante EstudianteDevolver = new Estudiante();
            EstudianteDevolver = BuscarEstudiante(legajo);
            Libro LibroDevolver = ListaLibros[indiceLibro];
            if (LibroDevolver.Prestado)
            {
                if (EstudianteDevolver != null)
                {

                    foreach (var libro in EstudianteDevolver.Libros)
                    {
                        if (libro == LibroDevolver.Titulo)
                        {
                            EstudianteDevolver.Libros.Remove($"{LibroDevolver.Titulo}");
                            LibroDevolver.Devolver();
                            return $"Libro devuelto con exito ";

                        }

                    }
                }

                else
                {
                    return "El estudiante no se encuentra registrado";
                }

            }
            return "El libro no se encuentra en su lista de Prestados";


        }
        public string ConsultaLibrosEstudiante(uint Legajo)
        {
            Estudiante ConsultaEstudiante = BuscarEstudiante(Legajo);
            string LibrosEstudiante = "\t LIBROS PRESTADOS AL ESTUDIANTE \n";
            if (ConsultaEstudiante != null)
            {
                foreach (var titulo in ConsultaEstudiante.Libros)
                {
                    if (ConsultaEstudiante.Libros.Count != 0)
                    { LibrosEstudiante += $"\t {titulo} \n"; }
                    else { LibrosEstudiante = "No se han prestado libros a este Estudiante"; }
                }
            }
            return LibrosEstudiante;
        }
    }
    }


