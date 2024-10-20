using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_scape
{
    class Juego
    {
        private Laberinto laberinto;
        private Jugador jugador;
        private int salidaFila;
        private int salidaColumna;

        // Constructor del juego
        public Juego(int filas, int columnas)
        {
            laberinto = new Laberinto(filas, columnas);
            jugador = new Jugador();
            salidaFila = filas - 1; // La salida estará en la última fila
            salidaColumna = columnas - 1; // y en la última columna
        }

        // Método que inicia el bucle principal del juego
        public void Iniciar()
        {
            while (true)
            {
                Console.Clear();
                laberinto.MostrarLaberinto(jugador.Fila, jugador.Columna, salidaFila, salidaColumna);

                // Verificar si el jugador ha llegado a la salida
                if (jugador.Fila == salidaFila && jugador.Columna == salidaColumna)
                {
                    Console.WriteLine("¡Felicidades! Has escapado del laberinto.");
                    break;
                }

                // Pedir al jugador que ingrese un movimiento
                Console.WriteLine("Mueve usando las teclas W (arriba), S (abajo), A (izquierda), D (derecha): ");
                char movimiento = Console.ReadKey().KeyChar;

                // Mover al jugador
                jugador.Mover(movimiento, laberinto);
            }
        }
    }
}
