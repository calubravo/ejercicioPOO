using System.Text.Json;
using System.Text.Json.Serialization;

namespace EjercicioPoo
{
    internal class Program
    {
        static void Main()
        {
            #region Carga de datos
            string data = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"data.json")   );

            #endregion

            var option = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            
            Biblioteca biblioteca = new Biblioteca
            {
                ListaLibros = JsonSerializer.Deserialize<List<Libro>>(data, option)!
            };

            //Gestionar los prestamos de libros de una biblioteca
            char Opcion;
            uint Legajo;
            string Titulo;
            int Seleccion;
            do
            {

                char.TryParse(Interfaz.DarOpcion().ToUpper(), out Opcion);

                switch (Opcion)
                {
                    case 'A':
                        while (uint.TryParse(Interfaz.PedirDato("Legajo del estudiante a registrar"), out Legajo) == false)
                        {
                            Interfaz.MostrarInfo("Legajo no valido");
                        }
                        if (biblioteca.LegajoUnico(Legajo))
                        {
                           biblioteca.RegistrarEstudiante(Legajo);
                        }
                        else
                        {
                            Interfaz.MostrarInfo("Legajo ya registrado previamente");
                        }
                        break;
                    // se debe poder prestar libros a estudiantes: 
                    //  *  solo hay una copia por libro y hay que verificar a la hora de prestarlo si lo tenemos disponible o no
                    case 'B':
                        while (uint.TryParse(Interfaz.PedirDato("Legajo"), out Legajo) == false)
                        {
                            Interfaz.MostrarInfo("Legajo inválido");
                        }
                        Console.WriteLine(biblioteca.ListarTitulos());
                        Seleccion = int.Parse(Interfaz.PedirDato("Seleccione el indice del libro a prestar"));
                        while (Seleccion < 0 || Seleccion > biblioteca.ListaLibros.Count)
                        {
                            Interfaz.MostrarInfo("El indice no corresponde a ningun Titulo");
                            Seleccion = ushort.Parse(Interfaz.PedirDato("Seleccione el indice del libro a prestar"));
                        }
                        Interfaz.MostrarInfo(biblioteca.PrestarLibro(Legajo,Seleccion));
                        break;
                                 // Se debe poder devolver libros 
                    case 'C':
                        while (uint.TryParse(Interfaz.PedirDato("Identificador del estudiante que desea devolver el libro"), out Legajo) == false)
                        {
                            Interfaz.MostrarInfo("El identificador debe ser un entero sin signo");
                        }
                        Console.WriteLine(biblioteca.ListarTitulos());
                        Seleccion = int.Parse(Interfaz.PedirDato("Seleccione el indice del libro a devolver"));
                        while (Seleccion < 0 || Seleccion > biblioteca.ListaLibros.Count)
                        {
                            Interfaz.MostrarInfo("El indice no corresponde a ningun Titulo");
                            Seleccion = ushort.Parse(Interfaz.PedirDato("Seleccione el indice del libro a devolver"));
                        }
                        Interfaz.MostrarInfo(biblioteca.DevolverLibro( Legajo,Seleccion));
                        break;
                        // Se debe poder listar todos los libros  y los que se prestaron
                    case 'D':
                        Interfaz.MostrarInfo(biblioteca.ListarLibros());
                        break;
                        // Se debe poder consultar los libros que tiene prestado un estudiante en particular
                    case 'E':
                        while (uint.TryParse(Interfaz.PedirDato("Legajo del Estudiante"), out Legajo) == false)
                        {
                            Interfaz.MostrarInfo("Estudiante no encontrado");
                        }
                        Interfaz.MostrarInfo(biblioteca.ConsultaLibrosEstudiante(Legajo));
                        break;
                }

            } while (Opcion != 'S');


        
           

    
 
   
   


}


    }
}