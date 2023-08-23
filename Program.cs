using System;

namespace AstuciaNaval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al juego de astucia naval");

            string[,] TableroBarcos = new string[10, 10];
            string[,] tablero = new string[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tablero[i, j] = " ~ ";
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(tablero[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Seleccione la orientación del barco\n 0. Horizontal\n 1. Vertical");
            int orientacion = int.Parse(Console.ReadLine());

            while (orientacion != 0 && orientacion != 1)
            {
                Console.WriteLine("Opción inválida, ingrese una opción válida: ");
                orientacion = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Ingrese el tamaño del barco entre 2 y 5");
            int tamanoBarco = int.Parse(Console.ReadLine());

            while (tamanoBarco < 2 || tamanoBarco > 5)
            {
                Console.WriteLine("Tamaño incorrecto.");
                tamanoBarco = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Ingrese la fila donde desea ubicar el barco:");
            int fila = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la columna donde desea ubicar el barco:");
            int columna = int.Parse(Console.ReadLine());

            if (orientacion == 0)
            {
                while (columna + tamanoBarco - 1 >= 10)
                {
                    Console.WriteLine("El barco no cabe en esa posición.");
                    Console.WriteLine("Ingrese la fila donde desea ubicar el barco:");
                     fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la columna donde desea ubicar el barco:");
                    columna = int.Parse(Console.ReadLine());

                }

                for (int i = 0; i < tamanoBarco; i++)
                {
                    TableroBarcos[fila, columna + i] = " B ";
                }
            }
            else if (orientacion == 1)
            {
                while (fila + tamanoBarco - 1 >= 10)
                {
                    Console.WriteLine("El barco no cabe en esa posición.");
                    Console.WriteLine("Ingrese la fila donde desea ubicar el barco:");
                    fila = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese la columna donde desea ubicar el barco:");
                    columna = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < tamanoBarco; i++)
                {
                    TableroBarcos[fila + i, columna] = " B ";
                }
            }

            int barcosRestantes = ContarBarcos(TableroBarcos);

            while (barcosRestantes > 0)
            {
                Console.WriteLine("Ingrese la fila para iniciar ataque:");
                int filaAtaque = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese columna para iniciar ataque:");
                int columnaAtaque = int.Parse(Console.ReadLine());

                if (filaAtaque >= 0 && filaAtaque < 10 && columnaAtaque >= 0 && columnaAtaque < 10)
                {
                    if (TableroBarcos[filaAtaque, columnaAtaque] == " B ")
                    {
                        Console.WriteLine("¡Ataque exitoso!");
                        tablero[filaAtaque, columnaAtaque] = " X ";
                        barcosRestantes--;

                        tablero[filaAtaque, columnaAtaque] = " 0 ";

                        for (int i = 0; i < 10; i++)
                        {
                           
                            for (int j = 0; j < 10; j++)
                            {
                                Console.Write(tablero[i, j] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else if (tablero[filaAtaque, columnaAtaque] == " X ")
                    {
                        Console.WriteLine("Ya atacaste esa posición antes.");
                    }
                    else
                    {
                        Console.WriteLine("¡Ataque fallido!");
                        tablero[filaAtaque, columnaAtaque] = " X ";

                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                Console.Write(tablero[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Posición inválida. Ingrese coordenadas válidas.");
                }
            }

            Console.WriteLine("¡Has hundido todos los barcos enemigos! ¡Ganaste!");
        }

        static int ContarBarcos(string[,] tablero)
        {
            int contador = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (tablero[i, j] == " B ")
                    {
                        contador++;
                    }
                }
            }

            return contador;
        }
    }
}