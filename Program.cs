using System;

class Program
{
    static void Main()
    {
        // Definir tamaño del laberinto
        int filas = 5;
        int columnas = 5;

        // Definir el laberinto (1 es una pared, 0 es espacio libre)
        int[,] laberinto = {
            { 0, 0, 0, 1, 0 },
            { 1, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 1, 0 }
        };

        // Posición inicial del jugador
        int jugadorFila = 0;
        int jugadorColumna = 0;

        // Posición de la salida
        int salidaFila = 4;
        int salidaColumna = 4;

        // Bucle principal del juego
        while (true)
        {
            Console.Clear();

            // Mostrar el laberinto y la posición del jugador
            MostrarLaberinto(laberinto, filas, columnas, jugadorFila, jugadorColumna, salidaFila, salidaColumna);

            // Verificar si el jugador ha llegado a la salida
            if (jugadorFila == salidaFila && jugadorColumna == salidaColumna)
            {
                Console.WriteLine("¡Felicidades! Has escapado del laberinto.");
                break;
            }

            // Pedir al jugador que ingrese un movimiento
            Console.WriteLine("Mueve usando las teclas W (arriba), S (abajo), A (izquierda), D (derecha): ");
            char movimiento = Console.ReadKey().KeyChar;

            // Procesar el movimiento
            int nuevaFila = jugadorFila;
            int nuevaColumna = jugadorColumna;

            if (movimiento == 'w' || movimiento == 'W')
                nuevaFila--;
            else if (movimiento == 's' || movimiento == 'S')
                nuevaFila++;
            else if (movimiento == 'a' || movimiento == 'A')
                nuevaColumna--;
            else if (movimiento == 'd' || movimiento == 'D')
                nuevaColumna++;

            // Verificar si el movimiento es válido
            if (EsMovimientoValido(laberinto, filas, columnas, nuevaFila, nuevaColumna))
            {
                jugadorFila = nuevaFila;
                jugadorColumna = nuevaColumna;
            }
            else
            {
                Console.WriteLine("\nMovimiento inválido. Inténtalo de nuevo.");
                Console.ReadKey(); // Esperar para que el jugador vea el mensaje
            }
        }
    }

    // Función para mostrar el laberinto
    static void MostrarLaberinto(int[,] laberinto, int filas, int columnas, int jugadorFila, int jugadorColumna, int salidaFila, int salidaColumna)
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (i == jugadorFila && j == jugadorColumna)
                    Console.Write("P "); // P representa al jugador
                else if (i == salidaFila && j == salidaColumna)
                    Console.Write("S "); // S representa la salida
                else if (laberinto[i, j] == 1)
                    Console.Write("# "); // # representa una pared
                else
                    Console.Write(". "); // . representa un espacio vacío
            }
            Console.WriteLine();
        }
    }

    // Función para verificar si el movimiento es válido
    static bool EsMovimientoValido(int[,] laberinto, int filas, int columnas, int fila, int columna)
    {
        if (fila < 0 || fila >= filas || columna < 0 || columna >= columnas)
            return false; // Movimiento fuera de los límites
        if (laberinto[fila, columna] == 1)
            return false; // Movimiento hacia una pared
        return true;
    }
}
