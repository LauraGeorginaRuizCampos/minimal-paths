using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal class Graph
    {
        // Diccionario que almacena la lista de adyacencia del grafo. 
        // Cada clave es un nodo, y el valor es una lista de nodos vecinos conectados.
        public Dictionary<int, List<int>> adjacencyList;

        // Variable que indica si el grafo es dirigido o no.
        private bool isDirected;

        // Constructor que inicializa el grafo y define si es dirigido o no.
        public Graph(bool isDirected)
        {
            adjacencyList = new Dictionary<int, List<int>>(); // Inicializa el diccionario vacío para el grafo.
            this.isDirected = isDirected; // Define si el grafo es dirigido o no.
        }

        // Método para agregar un nodo al grafo.
        public void AddNode(int node)
        {
            // Solo agrega el nodo si no está ya presente en el grafo.
            if (!adjacencyList.ContainsKey(node))
                adjacencyList.Add(node, new List<int>());
        }

        // Método para agregar una arista entre dos nodos (source -> destination).
        public void AddEdge(int source, int destination)
        {
            adjacencyList[source].Add(destination); // Agrega el destino a la lista de adyacencia del nodo fuente.
            if (!isDirected)
            {
                adjacencyList[destination].Add(source); // Si el grafo no es dirigido, agrega también la arista inversa.
            }
        }

        // Método para imprimir el grafo en consola.
        public void Print()
        {
            // Recorre cada nodo y sus vecinos, mostrando su lista de adyacencia.
            foreach (KeyValuePair<int, List<int>> entry in adjacencyList)
            {
                Console.Write(entry.Key + " -> [");
                for (int i = 0; i < entry.Value.Count; i++)
                {
                    Console.Write(" " + entry.Value[i] + " "); // Muestra cada vecino del nodo.
                }
                Console.WriteLine("]");
            }
        }

        // Método para verificar si un nodo existe en el grafo.
        public bool ContainsNode(int node)
        {
            return adjacencyList.ContainsKey(node); // Retorna si el nodo está en el grafo.
        }

        // Método para ejecutar el algoritmo de Dijkstra y calcular las distancias más cortas desde un nodo de inicio.
        public void Dijkstra(int start)
        {
            var nodes = adjacencyList.Keys.ToList(); // Extrae la lista de nodos.
            Dictionary<int, int> dist = nodes.ToDictionary(n => n, n => int.MaxValue); // Inicializa las distancias a infinito.
            dist[start] = 0; // La distancia desde el nodo de inicio es 0.
            HashSet<int> visited = new HashSet<int>(); // Conjunto de nodos visitados.

            // Realiza el algoritmo hasta que todos los nodos sean visitados.
            while (visited.Count < nodes.Count)
            {
                int u = -1;
                // Busca el nodo con la distancia más corta que aún no ha sido visitado.
                foreach (int node in nodes)
                {
                    if (!visited.Contains(node) && (u == -1 || dist[node] < dist[u]))
                    {
                        u = node;
                    }
                }

                visited.Add(u); // Marca el nodo como visitado.

                // Actualiza las distancias de los vecinos del nodo actual.
                foreach (int neighbor in adjacencyList[u])
                {
                    int newDist = dist[u] + 1; // Asumimos que todos los pesos de las aristas son 1.
                    if (newDist < dist[neighbor]) // Si encontramos una distancia más corta, la actualizamos.
                    {
                        dist[neighbor] = newDist;
                    }
                }
            }

            // Imprime las distancias calculadas desde el nodo de inicio a todos los demás nodos.
            foreach (var node in nodes)
            {
                Console.WriteLine($"Distancia desde {start} a {node}: {dist[node]}");
            }
        }

        // Método para ejecutar el algoritmo de Floyd-Warshall y calcular las distancias más cortas entre todos los pares de nodos.
        public void Floyd()
        {
            var nodes = adjacencyList.Keys.ToList(); // Extrae la lista de nodos.
            int n = nodes.Count;
            int[,] dist = new int[n, n]; // Matriz para almacenar las distancias entre nodos.

            // Inicializa la matriz de distancias.
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    dist[i, j] = (i == j) ? 0 : int.MaxValue; // La distancia de un nodo a sí mismo es 0, y a otros es infinita.

            // Asigna las distancias directas entre nodos conectados por aristas.
            foreach (var node in adjacencyList)
            {
                int u = nodes.IndexOf(node.Key); // Índice del nodo actual.
                foreach (int neighbor in node.Value)
                {
                    int v = nodes.IndexOf(neighbor); // Índice del vecino.
                    dist[u, v] = 1; // Asumimos peso 1 en las aristas.
                }
            }

            // Ejecuta el algoritmo de Floyd-Warshall para calcular las distancias más cortas.
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue)
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]); // Actualiza la distancia mínima entre nodos.
                    }
                }
            }

            // Imprime la matriz de distancias entre todos los pares de nodos.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, j] == int.MaxValue)
                        Console.Write("∞ "); // Si no hay camino, imprime infinito.
                    else
                        Console.Write(dist[i, j] + " "); // Si hay un camino, imprime la distancia.
                }
                Console.WriteLine();
            }
        }

        // Método para ejecutar el algoritmo de Warshall y encontrar si existe un camino entre cada par de nodos.
        public void Warshall()
        {
            var nodes = adjacencyList.Keys.ToList(); // Extrae la lista de nodos.
            int n = nodes.Count;
            bool[,] reach = new bool[n, n]; // Matriz que indica si hay un camino entre los nodos.

            // Inicializa la matriz de caminos.
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    reach[i, j] = (i == j); // Un nodo siempre tiene un camino hacia sí mismo.

            // Marca las conexiones directas entre nodos.
            foreach (var node in adjacencyList)
            {
                int u = nodes.IndexOf(node.Key); // Índice del nodo actual.
                foreach (int neighbor in node.Value)
                {
                    int v = nodes.IndexOf(neighbor); // Índice del vecino.
                    reach[u, v] = true; // Si hay una arista directa, marca el camino como verdadero.
                }
            }

            // Ejecuta el algoritmo de Warshall para encontrar todos los caminos posibles.
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (reach[i, k] && reach[k, j])
                            reach[i, j] = true; // Si hay un camino entre i -> k y k -> j, entonces hay un camino entre i -> j.
                    }
                }
            }

            // Imprime la matriz de caminos.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(reach[i, j] ? "1 " : "0 "); // Imprime 1 si hay un camino, 0 si no.
                }
                Console.WriteLine();
            }
        }
    }
}

