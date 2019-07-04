using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lesson7_alebastr
{
    class Program
    {
        static int[,] array;
        static int[] state;
        static void Main(string[] args)
        {
            string filePath = "data.txt";
            array = readGraph(filePath);
            if (array != null)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            PassWide(ref array);
            state = new int[array.GetLength(0)];
            Console.WriteLine("Дерево обхода графа в глубину:");
            PassDeepRec(0);
            Console.ReadKey();
        }
        /// <summary>
        /// Рекурсивный обход графа в глубину
        /// </summary>
        /// <param name="cur">текущая вершина</param>
        static void PassDeepRec(int cur)
        {
            if (IsAllPass(state))
            {
                return;
            }
            if (state[cur] == 2)
            {
                return;
            }
            Console.Write($"->{cur + 1}");
            state[cur] = 2;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                if (array[cur, i] > 0)
                {
                    PassDeepRec(i);
                }
            }
        }
        /// <summary>
        /// Обход графа в ширину
        /// </summary>
        /// <param name="arr">Матрица смежности</param>
        static void PassWide(ref int[,] arr)
        {
            int[] state = new int[arr.GetLength(0)];
            Queue<int> fifo = new Queue<int>();
            fifo.Enqueue(0);
            state[0] = 1;
            while (!IsAllPass(state)) //fifo.Count!=0
            {
                int cur = fifo.Dequeue();
                Console.WriteLine($"{cur+1} извлечен для обработки");
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    if (arr[cur, i] > 0 & state[i] == 0)
                    {
                        fifo.Enqueue(i);
                        Console.WriteLine($"{i+1} помещен в стек для обработки");
                        state[i] = 1; //В обработке
                    }
                }
                Console.WriteLine($"{cur+1} обработан");
                state[cur] = 2; //Обработан
            }
            Console.WriteLine($"Обход графа в ширину завершен");
        }
        /// <summary>
        /// Проверяет все ли вершины обработаны
        /// </summary>
        /// <param name="state">массив состояний</param>
        /// <returns>Истина, если все вершины пройдены, иначе ложь</returns>
        static bool IsAllPass(int[] state)
        {
            foreach (var item in state)
            {
                if (item < 2) return false;
            }
            return true;
        }
        /// <summary>
        /// Считывание матрицы смежности из файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Матрица смежности</returns>
        static int[,] readGraph(string fileName)
        {
            StreamReader fs;
            try
            {
                fs = new StreamReader(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка чтения файла. {e.Message}");
                return null;
            }
            int n = 0;
            if (!int.TryParse(fs.ReadLine(),out n))
            {
                Console.WriteLine($"Ошибка чтения размера массива.");
                return null;
            }
            int[,] array = new int[n, n];
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string[] strArr = fs.ReadLine().Split(' ');
                    for (int j = 0; j < strArr.Length; j++)
                    {
                        array[i, j] = int.Parse(strArr[j]);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка чтения массива из файла. {ex.Message}");
                return null;
            }
            return array;
        }
    }
}
