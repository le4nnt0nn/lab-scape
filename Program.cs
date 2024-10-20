using lab_scape;
using System;

class Program
{
    static void Main()
    {
        //Pedir usuario
        Console.Write("Introduce el nombre de usuario: ");
        string usuario = Console.ReadLine();
        usuario = string.IsNullOrEmpty(usuario) ? "Default" : usuario;

        // Pedir al usuario el tamaño del laberinto
        Console.Write("Introduce el número de filas: ");
        int filas = int.Parse(Console.ReadLine());

        Console.Write("Introduce el número de columnas: ");
        int columnas = int.Parse(Console.ReadLine());

        // Crear un nuevo juego con el tamaño especificado
        Juego juego = new Juego(usuario, filas, columnas);
        juego.Iniciar();
    }
}