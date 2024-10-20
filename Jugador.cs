using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_scape
{
    class Jugador
    {
        public int Fila { get; private set; }
        public int Columna { get; private set; }

        // Constructor que coloca al jugador en la posición inicial (0,0)
        public Jugador()
        {
            Fila = 0;
            Columna = 0;
        }

        // Método para mover al jugador
        public void Mover(char direccion, Laberinto laberinto)
        {
            int nuevaFila = Fila;
            int nuevaColumna = Columna;

            if (direccion == 'w' || direccion == 'W')
                nuevaFila--;
            else if (direccion == 's' || direccion == 'S')
                nuevaFila++;
            else if (direccion == 'a' || direccion == 'A')
                nuevaColumna--;
            else if (direccion == 'd' || direccion == 'D')
                nuevaColumna++;

            // Verificar si el movimiento es válido en el laberinto
            if (laberinto.EsMovimientoValido(nuevaFila, nuevaColumna))
            {
                Fila = nuevaFila;
                Columna = nuevaColumna;
            }
            else
            {
                Console.WriteLine("\nMovimiento inválido. Inténtalo de nuevo.");
                Console.ReadKey();
            }
        }
    }

}
