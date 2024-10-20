﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_scape
{
    class Laberinto
    {
        private int[,] mapa;
        private int filas;
        private int columnas;
        private Random random = new Random();

        // Constructor que genera el laberinto aleatorio
        public Laberinto(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            mapa = new int[filas, columnas];
            GenerarLaberinto();
        }

        // Método para generar un laberinto aleatorio
        private void GenerarLaberinto()
        {
            // Rellenar el laberinto con espacios vacíos y algunas paredes aleatorias
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // De manera aleatoria, poner paredes (1) o espacios libres (0)
                    // Se asegura que la posición inicial del jugador no tenga una pared
                    if (i == 0 && j == 0)
                    {
                        mapa[i, j] = 0;
                    }
                    else
                    {
                        mapa[i, j] = random.Next(0, 5) == 0 ? 1 : 0; // 20% de probabilidad de ser pared
                    }
                }
            }

            // Asegurarse que la salida tampoco tenga una pared
            mapa[filas - 1, columnas - 1] = 0;
        }

        // Método para mostrar el laberinto
        public void MostrarLaberinto(int jugadorFila, int jugadorColumna, int salidaFila, int salidaColumna)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (i == jugadorFila && j == jugadorColumna)
                        Console.Write("P "); // P representa al jugador
                    else if (i == salidaFila && j == salidaColumna)
                        Console.Write("S "); // S representa la salida
                    else if (mapa[i, j] == 1)
                        Console.Write("# "); // # representa una pared
                    else
                        Console.Write(". "); // . representa un espacio vacío
                }
                Console.WriteLine();
            }
        }

        // Método para verificar si un movimiento es válido
        public bool EsMovimientoValido(int fila, int columna)
        {
            if (fila < 0 || fila >= filas || columna < 0 || columna >= columnas)
                return false; // Movimiento fuera de los límites
            if (mapa[fila, columna] == 1)
                return false; // Movimiento hacia una pared
            return true;
        }

        // Obtener el número de filas del laberinto
        public int GetFilas()
        {
            return filas;
        }

        // Obtener el número de columnas del laberinto
        public int GetColumnas()
        {
            return columnas;
        }
    }
}