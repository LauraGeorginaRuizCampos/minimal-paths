using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pregunta al usuario si el grafo debe ser dirigido o no.
            Console.WriteLine("¿Desea que su grafo sea dirigido? (S/N)");
            string respuesta = Console.ReadLine();
            bool isDirected;

            // Si la respuesta es 'S' o 's', el grafo será dirigido. De lo contrario, será no dirigido.
            if (respuesta == "S" || respuesta == "s")
            {
                isDirected = true;
            }
            else
            {
                isDirected = false;
            }

            // Crea una instancia del grafo con la opción seleccionada (dirigido o no dirigido).
            Graph graph = new Graph(isDirected);

            int opcion = 0;

            // Bucle para mostrar un menú de opciones hasta que el usuario decida salir (opción 7).
            do
            {
                // Menú de opciones para el usuario.
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Agregar nodo");
                Console.WriteLine("2. Agregar arista");
                Console.WriteLine("3. Mostrar grafo");
                Console.WriteLine("4. Ejecutar algoritmo Dijkstra");
                Console.WriteLine("5. Ejecutar algoritmo Floyd");
                Console.WriteLine("6. Ejecutar algoritmo Warshall");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                string entrada = Console.ReadLine();

                // Intenta convertir la entrada del usuario en un número entero.
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Opción inválida, intenta de nuevo.");
                    continue; // Si la entrada no es válida, vuelve a mostrar el menú.
                }

                // Selección de la opción del menú.
                switch (opcion)
                {
                    // Caso 1: Agregar un nodo.
                    case 1:
                        Console.Write("Ingrese el número del nodo: ");
                        int nodo;
                        if (int.TryParse(Console.ReadLine(), out nodo)) // Intenta convertir la entrada en un número entero.
                        {
                            // Verifica si el nodo ya existe antes de agregarlo.
                            if (!graph.ContainsNode(nodo))
                            {
                                graph.AddNode(nodo); // Agrega el nodo al grafo.
                                Console.WriteLine($"Nodo {nodo} agregado.");
                            }
                            else
                            {
                                Console.WriteLine("Ese nodo ya existe."); // Si el nodo ya existe, muestra un mensaje de error.
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida."); // Si la entrada no es un número válido, muestra un mensaje de error.
                        }
                        break;

                    // Caso 2: Agregar una arista entre dos nodos.
                    case 2:
                        Console.Write("Ingrese el nodo origen: ");
                        int origen;
                        if (int.TryParse(Console.ReadLine(), out origen))
                        {
                            Console.Write("Ingrese el nodo destino: ");
                            int destino;
                            if (int.TryParse(Console.ReadLine(), out destino))
                            {
                                // Verifica si ambos nodos existen en el grafo antes de agregar la arista.
                                if (graph.ContainsNode(origen) && graph.ContainsNode(destino))
                                {
                                    graph.AddEdge(origen, destino); // Agrega la arista entre los dos nodos.
                                    Console.WriteLine($"Arista agregada de {origen} a {destino}.");
                                }
                                else
                                {
                                    Console.WriteLine("Uno o ambos nodos no existen."); // Si alguno de los nodos no existe, muestra un mensaje de error.
                                }
                            }
                            else
                            {
                                Console.WriteLine("Entrada inválida.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                        break;

                    // Caso 3: Mostrar el grafo actual.
                    case 3:
                        Console.WriteLine("Grafo actual:");
                        graph.Print(); // Llama al método Print para mostrar el grafo.
                        break;

                    // Caso 4: Ejecutar el algoritmo de Dijkstra para encontrar las distancias más cortas desde un nodo.
                    case 4:
                        Console.Write("Ingrese el nodo de inicio para Dijkstra: ");
                        int startDijkstra;
                        if (int.TryParse(Console.ReadLine(), out startDijkstra))
                        {
                            graph.Dijkstra(startDijkstra);  // Llama al método Dijkstra con el nodo de inicio.
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                        break;

                    // Caso 5: Ejecutar el algoritmo de Floyd-Warshall para encontrar las distancias más cortas entre todos los pares de nodos.
                    case 5:
                        Console.Write("Ingrese el nodo de inicio para Floyd: ");
                        int startFloyd;
                        if (int.TryParse(Console.ReadLine(), out startFloyd))
                        {
                            graph.Floyd();  // Llama al método Floyd para calcular las distancias.
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                        break;

                    // Caso 6: Ejecutar el algoritmo de Warshall para encontrar si existe un camino entre cada par de nodos.
                    case 6:
                        Console.Write("Ingrese el nodo de inicio para Warshall: ");
                        int startWarshall;
                        if (int.TryParse(Console.ReadLine(), out startWarshall))
                        {
                            graph.Warshall();  // Llama al método Warshall para encontrar los caminos.
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida.");
                        }
                        break;

                    // Caso 7: Salir del programa.
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;

                    // Caso por defecto: Opción no válida.
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 7); // El bucle continúa hasta que el usuario selecciona la opción 7 para salir.
        }
    }
}

