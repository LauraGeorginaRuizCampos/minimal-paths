# Minimal Paths

## Descripción del Proyecto

El proyecto **Minimal Paths** tiene como objetivo la implementación de algoritmos de búsqueda de caminos más cortos y análisis de conectividad en grafos dirigidos y no dirigidos. Se ofrece una interfaz simple de consola para interactuar con el grafo, agregar nodos y aristas, y ejecutar algoritmos como **Dijkstra**, **Floyd-Warshall** y **Warshall**.

### Objetivos del Proyecto:
- **Implementar un grafo dinámico** que permita agregar nodos y aristas.
- **Permitir elegir entre grafos dirigidos o no dirigidos**.
- **Implementar algoritmos clásicos** para encontrar los caminos más cortos:
  - **Dijkstra**: Encuentra el camino más corto desde un nodo fuente a todos los demás nodos, adecuado para grafos ponderados.
  - **Floyd-Warshall**: Calcula las distancias más cortas entre todos los pares de nodos.
  - **Warshall**: Determina si existe un camino entre cada par de nodos (verifica la conectividad).
- **Proveer una interfaz de consola simple** que guíe al usuario a través del proceso de creación del grafo y la ejecución de algoritmos.

### Tecnologías Utilizadas:
- **C#**: Lenguaje de programación utilizado para implementar los algoritmos y la estructura del grafo.
- **.NET**: Framework utilizado para la ejecución del código.

---

## Instrucciones de Instalación

### Requisitos Previos

1. **Visual Studio** o cualquier otro IDE compatible con C# y .NET Framework.
2. **.NET Core** (si deseas ejecutar el proyecto sin IDE).

### Pasos de Instalación

1. **Clonar el Repositorio**:
   Para obtener una copia local del proyecto, abre una terminal y ejecuta el siguiente comando:
   ```bash
   git clone https://github.com/LauraGeorginaRuizCampos/minimal-paths.git

    Abrir el Proyecto: Una vez que hayas clonado el repositorio, abre el archivo minimal paths.sln con Visual Studio o el editor de tu preferencia.

    Restaurar Dependencias: Si estás utilizando Visual Studio, simplemente abre el proyecto y Visual Studio restaurará las dependencias automáticamente. Si utilizas .NET Core, ejecuta el siguiente comando en la terminal:

    dotnet restore

    Compilar el Proyecto: En Visual Studio, selecciona Build > Build Solution o presiona Ctrl + Shift + B para compilar el proyecto.

    Ejecutar el Proyecto: Presiona F5 o selecciona Debug > Start Debugging en Visual Studio para ejecutar el programa.

Instrucciones de Uso
Interacción con el Programa

El programa permite al usuario interactuar con el grafo a través de un menú en la consola. A continuación se detalla el flujo y las opciones disponibles:

    Seleccionar si el grafo es dirigido o no dirigido: Al iniciar el programa, te pedirá que indiques si el grafo debe ser dirigido o no:

¿Desea que su grafo sea dirigido? (S/N)

Responde con S (Sí) si deseas un grafo dirigido, o N (No) para uno no dirigido.

Menú de Opciones: El programa presenta un menú con las siguientes opciones:

    --- MENÚ ---
    1. Agregar nodo
    2. Agregar arista
    3. Mostrar grafo
    4. Ejecutar algoritmo Dijkstra
    5. Ejecutar algoritmo Floyd
    6. Ejecutar algoritmo Warshall
    7. Salir
    Seleccione una opción: 

    Elige una opción del menú ingresando el número correspondiente.

Opciones del Menú:

    Agregar Nodo: Permite agregar un nodo al grafo. Si el nodo ya existe, el programa lo notificará.

Ingrese el número del nodo: 1
Nodo 1 agregado.

Agregar Arista: Permite agregar una arista entre dos nodos existentes. Asegúrate de que ambos nodos estén previamente creados. Si se agrega una arista en un grafo no dirigido, la arista se añade en ambas direcciones.

Ingrese el nodo origen: 1
Ingrese el nodo destino: 2
Arista agregada de 1 a 2.

Mostrar Grafo: Muestra una representación textual del grafo con sus nodos y aristas:

1 -> [ 2 ]
2 -> [ ]

Ejecutar Algoritmo Dijkstra: Ejecuta el algoritmo de Dijkstra desde un nodo fuente y muestra la distancia más corta a todos los demás nodos:

Ingrese el nodo de inicio para Dijkstra: 1
Distancia desde 1 a 2: 1
Distancia desde 1 a 3: ∞

Ejecutar Algoritmo Floyd: Ejecuta el algoritmo de Floyd-Warshall para calcular las distancias más cortas entre todos los pares de nodos:

Ingrese el nodo de inicio para Floyd: 1
0 1 ∞
∞ 0 1
∞ ∞ 0

Ejecutar Algoritmo Warshall: Ejecuta el algoritmo de Warshall para verificar la conectividad de todos los nodos:

    Ingrese el nodo de inicio para Warshall: 1
    1 1 0
    0 1 1
    0 0 1

    Salir: Salir del programa.

Ejemplos de Entrada y Salida Esperada
Ejemplo 1: Agregar Nodo y Arista

Entrada:

¿Desea que su grafo sea dirigido? (S/N): N
Seleccione una opción: 1
Ingrese el número del nodo: 1
Nodo 1 agregado.
Seleccione una opción: 2
Ingrese el nodo origen: 1
Ingrese el nodo destino: 2
Arista agregada de 1 a 2.

Salida:

Grafo actual:
1 -> [ 2 ]
2 -> [ 1 ]

Ejemplo 2: Ejecutar Dijkstra

Entrada:

Seleccione una opción: 4
Ingrese el nodo de inicio para Dijkstra: 1

Salida:

Distancia desde 1 a 1: 0
Distancia desde 1 a 2: 1

Explicación de los Algoritmos Implementados
1. Algoritmo de Dijkstra

Descripción: El algoritmo de Dijkstra es un algoritmo de búsqueda de caminos más cortos en un grafo ponderado. Comienza desde un nodo fuente y va "relajando" las distancias a todos los nodos adyacentes. El proceso se repite hasta que todos los nodos hayan sido visitados.

Pasos:

    Inicializar todas las distancias a infinito, excepto la del nodo fuente que es 0.

    Seleccionar el nodo con la distancia más corta y actualizar las distancias de sus vecinos.

    Repetir hasta que se haya procesado todos los nodos.

Complejidad: La complejidad temporal es O((V + E) log V), donde:

    V es el número de nodos.

    E es el número de aristas.

    El log V proviene del uso de una estructura de datos tipo heap (montículo).

2. Algoritmo de Floyd-Warshall

Descripción: El algoritmo de Floyd-Warshall es un algoritmo de programación dinámica utilizado para encontrar las distancias más cortas entre todos los pares de nodos en un grafo. Este algoritmo es adecuado para grafos densos o cuando se necesita conocer la distancia más corta entre todos los nodos, no solo entre un nodo fuente y los demás.

Pasos:

    Crear una matriz de distancias donde cada entrada representa la distancia entre dos nodos.

    Actualizar las distancias iterativamente para cada par de nodos considerando todos los nodos intermedios.

Complejidad: La complejidad es O(V^3), donde V es el número de nodos.
3. Algoritmo de Warshall

Descripción: El algoritmo de Warshall se utiliza para determinar si hay un camino entre cada par de nodos en un grafo dirigido o no dirigido. Es un caso especial del algoritmo de Floyd-Warshall, pero en lugar de calcular las distancias, solo verifica la existencia de caminos.

Pasos:

    Inicializar una matriz de conectividad que se llena con valores true o false.

    Actualizar las entradas en la matriz para reflejar si existe un camino entre los nodos.

Complejidad: La complejidad es O(V^3), donde V es el número de nodos.
Contribuciones

Si deseas contribuir a este proyecto, sigue estos pasos:

    Realiza un fork del repositorio.

    Crea una nueva rama para tus cambios (git checkout -b feature/nueva-funcionalidad).

    Realiza tus cambios y haz commit de los mismos.

    Push a tu repositorio fork (git push origin feature/nueva-funcionalidad).

    Abre un pull request en este repositorio.
