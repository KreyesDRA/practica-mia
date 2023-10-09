using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


            using System;
            using System.Collections.Generic;

class Program
        {
            struct Estudiante
            {
                public string cedula;
                public string nombre;
                public double promedio;
                public string condicion;
            }

            static List<Estudiante> estudiantes = new List<Estudiante>();

            static void Main(string[] args)
            {
                int opcion;
                do
                {
                    Console.WriteLine("Menú Principal");
                    Console.WriteLine("1. Inicializar Vectores");
                    Console.WriteLine("2. Incluir Estudiantes");
                    Console.WriteLine("3. Consultar Estudiantes");
                    Console.WriteLine("4. Modificar Estudiantes");
                    Console.WriteLine("5. Eliminar Estudiantes");
                    Console.WriteLine("6. Submenú Reportes");
                    Console.WriteLine("7. Salir");
                    Console.Write("Ingrese la opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            InicializarVectores();
                            break;
                        case 2:
                            IncluirEstudiantes();
                            break;
                        case 3:
                            ConsultarEstudiantes();
                            break;
                        case 4:
                            ModificarEstudiantes();
                            break;
                        case 5:
                            EliminarEstudiantes();
                            break;
                        case 6:
                            SubmenuReportes();
                            break;
                        case 7:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                } while (opcion != 7);
            }

            static void InicializarVectores()
            {
                estudiantes.Clear();
                Console.WriteLine("Vectores inicializados.");
            }

            static void IncluirEstudiantes()
            {
                Estudiante estudiante;
                Console.Write("Ingrese la cédula del estudiante: ");
                estudiante.cedula = Console.ReadLine();
                Console.Write("Ingrese el nombre del estudiante: ");
                estudiante.nombre = Console.ReadLine();
                Console.Write("Ingrese el promedio del estudiante: ");
                estudiante.promedio = Convert.ToDouble(Console.ReadLine());

                if (estudiante.promedio >= 70)
                    estudiante.condicion = "APROBADO";
                else if (estudiante.promedio >= 60)
                    estudiante.condicion = "REPROBADO";
                else
                    estudiante.condicion = "APLAZADO";

                estudiantes.Add(estudiante);
                Console.WriteLine("Estudiante incluido exitosamente.");
            }

            static void ConsultarEstudiantes()
            {
                Console.Write("Ingrese la cédula del estudiante a consultar: ");
                string cedula = Console.ReadLine();
                Estudiante estudiante = estudiantes.Find(e => e.cedula == cedula);
                if (estudiante.cedula != null)
                {
                    Console.WriteLine("Datos del estudiante:");
                    Console.WriteLine("Cédula: " + estudiante.cedula);
                    Console.WriteLine("Nombre: " + estudiante.nombre);
                    Console.WriteLine("Promedio: " + estudiante.promedio);
                    Console.WriteLine("Condición: " + estudiante.condicion);
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }
            }

            static void ModificarEstudiantes()
            {
                Console.Write("Ingrese la cédula del estudiante a modificar: ");
                string cedula = Console.ReadLine();
                Estudiante estudiante = estudiantes.Find(e => e.cedula == cedula);
                if (estudiante.cedula != null)
                {
                    Console.Write("Ingrese el nuevo nombre del estudiante: ");
                    estudiante.nombre = Console.ReadLine();
                    Console.Write("Ingrese el nuevo promedio del estudiante: ");
                    estudiante.promedio = Convert.ToDouble(Console.ReadLine());

                    if (estudiante.promedio >= 70)
                        estudiante.condicion = "APROBADO";
                    else if (estudiante.promedio >= 60)
                        estudiante.condicion = "REPROBADO";
                    else
                        estudiante.condicion = "APLAZADO";

                    Console.WriteLine("Estudiante modificado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }
            }

            static void EliminarEstudiantes()
            {
                Console.Write("Ingrese la cédula del estudiante a eliminar: ");
                string cedula = Console.ReadLine();
                Estudiante estudiante = estudiantes.Find(e => e.cedula == cedula);
                if (estudiante.cedula != null)
                {
                    estudiantes.Remove(estudiante);
                    Console.WriteLine("Estudiante eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Estudiante no encontrado.");
                }
            }

            static void SubmenuReportes()
            {
                int opcion;
                do
                {
                    Console.WriteLine("Submenú Reportes");
                    Console.WriteLine("1. Reporte Estudiantes por Condición");
                    Console.WriteLine("2. Reporte Todos los datos");
                    Console.WriteLine("3. Regresar al Menú Principal");
                    Console.Write("Ingrese la opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            ReporteEstudiantesPorCondicion();
                            break;
                        case 2:
                            ReporteTodosLosDatos();
                            break;
                        case 3:
                            Console.WriteLine("Regresando al Menú Principal...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                } while (opcion != 3);
            }

            static void ReporteEstudiantesPorCondicion()
            {
                Console.WriteLine("Elija una condición:");
                Console.WriteLine("1. APROBADO");
                Console.WriteLine("2. REPROBADO");
                Console.WriteLine("3. APLAZADO");
                Console.Write("Ingrese la opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());
                string condicion = "";

                switch (opcion)
                {
                    case 1:
                        condicion = "APROBADO";
                        break;
                    case 2:
                        condicion = "REPROBADO";
                        break;
                    case 3:
                        condicion = "APLAZADO";
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        return;
                }

                Console.WriteLine($"Estudiantes con condición {condicion}:");
                foreach (var estudiante in estudiantes)
                {
                    if (estudiante.condicion == condicion)
                    {
                        Console.WriteLine($"Cédula: {estudiante.cedula}, Nombre: {estudiante.nombre}, Promedio: {estudiante.promedio}");
                    }
                }
            }

            static void ReporteTodosLosDatos()
            {
                if (estudiantes.Count == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados.");
                    return;
                }

                double promedioMayor = estudiantes[0].promedio;
                double promedioMenor = estudiantes[0].promedio;
                Estudiante estudiantePromedioMayor = estudiantes[0];
                Estudiante estudiantePromedioMenor = estudiantes[0];

                foreach (var estudiante in estudiantes)
                {
                    if (estudiante.promedio > promedioMayor)
                    {
                        promedioMayor = estudiante.promedio;
                        estudiantePromedioMayor = estudiante;
                    }

                    if (estudiante.promedio < promedioMenor)
                    {
                        promedioMenor = estudiante.promedio;
                        estudiantePromedioMenor = estudiante;
                    }
                }

                Console.WriteLine("Reporte de todos los datos:");
                Console.WriteLine($"Cantidad de estudiantes: {estudiantes.Count}");
                Console.WriteLine($"Estudiante con el promedio mayor: Cédula: {estudiantePromedioMayor.cedula}, Nombre: {estudiantePromedioMayor.nombre}, Promedio: {estudiantePromedioMayor.promedio}");
                Console.WriteLine($"Estudiante con el promedio menor: Cédula: {estudiantePromedioMenor.cedula}, Nombre: {estudiantePromedioMenor.nombre}, Promedio: {estudiantePromedioMenor.promedio}");
            }
}
