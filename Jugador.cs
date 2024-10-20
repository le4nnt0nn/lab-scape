using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_scape
{
    class Jugador
    {
        public string Usuario { get; private set; }

        public int Puntuacion { get; private set; }
        public int Fila { get; private set; }
        public int Columna { get; private set; }

        // Constructor que coloca al jugador en la posición inicial (0,0)
        public Jugador(string usuario)
        {
            this.Usuario = usuario;
            this.Puntuacion = 0;
            this.Fila = 0;
            this.Columna = 0;
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

                // Verificar si jugador recoge punto
                if(laberinto.EsPunto(Fila, Columna)) {
                    Puntuacion++;
                    laberinto.RecogerPunto(Fila, Columna);
                }
            }
            else
            {
                Console.WriteLine("\nMovimiento inválido. Inténtalo de nuevo.");
                Console.ReadKey();
            }
        }
    }

}
