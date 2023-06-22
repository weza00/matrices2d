using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace matrices2d
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Declaración de la Matriz
            */
            int f, c;
            Console.Write("Ingresa cuántas filas deseas que tenga la matriz: ");
            f = int.Parse(Console.ReadLine());
            Console.Write("Ingresa cuántas columnas deseas que tenga la matriz: ");
            c = int.Parse(Console.ReadLine());
            int[,] matrix = new int[f, c];
            Console.Clear();
            /*
             * Muestra la matriz con números en cada celda.
            */ 
            Console.WriteLine($"Matriz {f} x {c} creada.\n");
            CrearMatriz(matrix, f, c);
            /*
             * Operaciones de cada fila y cada columna
            */
            double[] promf = new double[f];
            double[] promc = new double[c];
            Console.WriteLine("\n------------------SUMA DE CADA FILA Y COLUMNA------------------");
            SumasPromedios(f, c, matrix, promf, promc);
            Console.WriteLine("\n-----------------------MAXIMOS Y MINIMOS-----------------------");
            MaxyMin(f, c, matrix);
            /*
             * Operaciones con todo el array
            */
            Console.WriteLine("\n---------------------SUMA DE TODO EL ARRAY---------------------");
            int suma = 0, conti = 0;
            foreach (int e in matrix)
            {
                suma += e;
                conti++;
            }
            double promArray = (double)suma / conti;
            Console.WriteLine(suma);
            Console.WriteLine("\n-------------------PROMEDIO DE TODO EL ARRAY-------------------");
            Console.WriteLine(promArray);
            Console.WriteLine("\n---------------MINIMO Y MAXIMO DE TODO EL ARRAY----------------");
            int maxArray = matrix[0, 0];
            int minArray = matrix[0, 0];
            foreach(int elem in matrix)
            {
                if (elem > maxArray)
                    maxArray = elem;
                else if (elem < minArray)
                    minArray = elem;
            }
            Console.WriteLine($"El Máximo del array es {maxArray}\nEl Mínimo del array es {minArray}.");
            Console.ReadKey();
        }
        public static void CrearMatriz(int[,] matrix, int f, int c)
        {
            int cont = 1, contneg = 0;
            int co = 1;
            for (int x = 0; x < c; x++)
                Console.Write($"C{x + 1}\t");
            Console.WriteLine("\n\n");
            for (int i = 0; i < f; i++)
            {
                if (i % 2 != 0)
                {
                    contneg = cont - 1;
                    contneg += c;
                    cont = contneg + 1;
                }
                for (int j = 0; j < c; j++)
                {
                    if (i % 2 != 0)
                    {
                        matrix[i, j] = contneg;
                        contneg--;
                    }
                    else
                    {
                        matrix[i, j] = cont;
                        cont++;
                    }
                    Console.Write(matrix[i, j] + "\t");
                    if (j == (c - 1))
                    {
                        Console.WriteLine($"F{co}");
                        co++;
                    }
                }

                Console.WriteLine();
            }
        }
        public static void SumasPromedios(int f, int c, int[,] matrix, double[] promf, double[]promc)
        {
            int c1, c2;
            for (int i = 0; i < f; i++)
            {
                c1 = 0;
                int sumaf = 0;
                for (int j = 0; j < c; j++)
                {
                    sumaf += matrix[i, j];
                    c1++;
                }
                promf[i] = (double)sumaf / c1;
                Console.Write($"F{i + 1}: {sumaf}   ");
            }
            Console.WriteLine();
            for (int i = 0; i < c; i++)
            {
                c2 = 0;
                int sumac = 0;
                for (int j = 0; j < f; j++)
                {
                    sumac += matrix[j, i];
                    c2++;
                }
                promc[i] = (double)sumac / c2;
                Console.Write($"C{i + 1}: {sumac}   ");
            }
            Console.WriteLine("\n-------------------------PROMEDIOS-----------------------------");
            for (int i = 0; i < f; i++)
                Console.Write($"F{i + 1}: {promf[i]}   ");
            Console.WriteLine();
            for (int i = 0; i < c; i++)
                Console.Write($"C{i + 1}: {promc[i]}   ");
        }
        public static void MaxyMin(int f, int c, int[,] matrix)
        {
            int maxf, minf, maxc, minc;
            for(int i = 0; i < f; i++)
            {
                maxf = matrix[i, 0];
                minf = matrix[i, 0];
                for (int j = 0; j < c; j++)
                {
                    if (matrix[i, j] > maxf) 
                    {
                        maxf = matrix[i, j];
                    }
                    if (matrix[i, j] < minf)
                    {
                        minf = matrix[i, j];
                    }
                }
                Console.WriteLine($"F{i + 1}: Max={maxf}, Min={minf}");
            }
            Console.WriteLine();
            for (int i = 0; i < c; i++)
            {
                maxc = matrix[0, i];
                minc = matrix[0, i];
                for (int j = 1; j < f; j++)
                {
                    if (matrix[j, i] > maxc)
                    {
                        maxc = matrix[j, i];
                    }
                    if (matrix[j, i] < minc)
                    {
                        minc = matrix[j, i];
                    }
                }
                Console.WriteLine($"C{i + 1}: Max={maxc}, Min={minc}");
            }
        }
    }
}
