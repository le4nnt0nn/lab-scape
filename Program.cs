using lab_scape;
using System;

class Program
{
    static void Main()
    {
        // Pedir al usuario el tamaño del laberinto
        Console.Write("Introduce el número de filas: ");
        int filas = int.Parse(Console.ReadLine());

        Console.Write("Introduce el número de columnas: ");
        int columnas = int.Parse(Console.ReadLine());

        // Crear un nuevo juego con el tamaño especificado
        Juego juego = new Juego(filas, columnas);
        juego.Iniciar();
    }
}