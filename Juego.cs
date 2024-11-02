using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Timer = System.Timers.Timer;

namespace lab_scape
{
    class Juego
    {
        private Laberinto laberinto;
        private Jugador jugador;
        private int salidaFila;
        private int salidaColumna;
        private int tiempoRestante = 30;
        private Timer temporizador;

        // Constructor del juego
        public Juego(string usuario, int filas, int columnas)
        {
            laberinto = new Laberinto(filas, columnas);
            jugador = new Jugador(usuario);
            salidaFila = filas - 1; // La salida estará en la última fila
            salidaColumna = columnas - 1; // y en la última columna
        }

        // Método que inicia el bucle principal del juego
        public void Iniciar()
        {
            // Reducir el tiempo cada segundo
            temporizador = new Timer(1000);
            temporizador.Elapsed += Temporizador_Elapsed; // Evento que ejecuta el método que resta tiempo (cada segundo por el Timer asociado arriba)
            temporizador.Start();

            while (true)
            {
                Console.Clear();
                laberinto.MostrarLaberinto(jugador.Fila, jugador.Columna, salidaFila, salidaColumna, jugador.Puntuacion);
                Console.WriteLine("Tiempo restante: " + tiempoRestante + " segundos.");

                // Verificar si el tiempo se ha agotado
                if (tiempoRestante <= 0)
                {
                    Console.WriteLine("¡Has perdido! Se agotó el tiempo.");
                    temporizador.Stop();
                    break;
                }

                // Verificar si el jugador ha llegado a la salida
                if (jugador.Fila == salidaFila && jugador.Columna == salidaColumna)
                {
                    Console.WriteLine("¡Felicidades, " + jugador.Usuario + "! Has escapado del laberinto.");
                    Console.WriteLine("Puntuación final: " + jugador.Puntuacion);
                    temporizador.Stop();
                    break;
                }

                // Pedir al jugador que ingrese un movimiento
                Console.WriteLine("Mueve usando las teclas W (arriba), S (abajo), A (izquierda), D (derecha): ");
                char movimiento = Console.ReadKey().KeyChar;

                // Mover al jugador
                jugador.Mover(movimiento, laberinto);
            }
        }

        // Método que controla el temporizador
        private void Temporizador_Elapsed(object sender, ElapsedEventArgs e)
        {
            tiempoRestante--;

            if (tiempoRestante <= 0)
            {
                temporizador.Stop();
            }
        }
    }
}
