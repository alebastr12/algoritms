using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4_alebastr
{
    class Program
    {
        static int[,] PossibleMove = new int[8,2] {{-1, -2}, {-2, -1}, {-2,  1}, { 1, -2}, 
                                                   {-1,  2}, { 2, -1}, { 1,  2}, { 2,  1}}; //Возможные ходы коня

        static int MaxX = 8; //Размеры доски
        static int MaxY = 8;
        static int[,] desc = new int[MaxX,MaxY]; //Доска
        static void Main(string[] args)
        {
            #region Поиск максимальной общей подпоследовательности
            char[] a = { 'G', 'E', 'E', 'K', 'B', 'R', 'A', 'I', 'N', 'S', 'E', 'S' };
            char[] b = { 'G', 'E', 'E', 'K', 'M', 'I', 'N', 'D', 'S' };
            LcsLengthArr(a, b);
            //Console.ReadKey();
            #endregion

            #region Обход доски конем
            if (SearchSolution(0, 0, 1))
            {
                for (int i = 0; i < desc.GetLength(0); i++)
                {
                    for (int j = 0; j < desc.GetLength(1); j++)
                    {
                        Console.Write($"{desc[j,i],-3}");
                    }
                    Console.WriteLine();
                }
            } else
            {
                Console.WriteLine("Решений не найдено");
            }
            Console.ReadKey();
            #endregion
        }
        /// <summary>
        /// Рекурсивная функция обхода доски конем
        /// </summary>
        /// <param name="cur_x">Текущая координата x</param>
        /// <param name="cur_y">Текущая координата y</param>
        /// <param name="n">Истина, если есть решение, иначе ложь</param>
        /// <returns></returns>
        static bool SearchSolution(int cur_x, int cur_y, int n)
        {
            int next_x = 0, next_y = 0;
            desc[cur_x,cur_y] = n;

            if (n > (MaxX * MaxY - 1))
                return true;

            for (int i = 0; i < PossibleMove.GetLength(0); i++)
            {
                next_x = cur_x + PossibleMove[i,0];
                next_y = cur_y + PossibleMove[i,1];
                if (MovePossible(next_x, next_y) && SearchSolution(next_x, next_y, n + 1))
                    return true;
            }

            desc[cur_x,cur_y] = 0;
            n++;
            return false;
        }
        /// <summary>
        /// Функция определяет возможно ли сделать ход в поле
        /// </summary>
        /// <param name="x">Координата x поля</param>
        /// <param name="y">Координата y поля</param>
        /// <returns>Истина, если возможно, иначе ложь</returns>
        static bool MovePossible(int x, int y)
        {
            return (x >= 0 & y >= 0 & x < MaxX & y < MaxY) ? (desc[x, y] == 0) : false;
        }

        /// <summary>
        /// Функция заполняет и выводит матрицу подпоследовательностей
        /// </summary>
        /// <param name="a">Последовательность</param>
        /// <param name="b">Последовательность</param>
        /// <returns>Длинна максимальной общей подпоследовательности</returns>
        static int LcsLengthArr(char[] a, char[] b)
        {
            int[,] arr = new int[a.Length+1, b.Length+1];
            int m = a.Length+1;
            int n = b.Length+1;
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (a[i-1] == b[j-1])
                    {
                        arr[i, j] = arr[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        if (arr[i - 1,j] >= arr[i,j - 1])
                        {
                            arr[i, j] = arr[i - 1, j];
                        }
                        else
                        {
                            arr[i, j] = arr[i, j - 1];
                        }
                    }
         
                }
            }
            for (int r = 0; r < arr.GetLength(0); r++)
            {
                Console.Write((r == 0) ? "    " : $"{a[r - 1]} ");
            }
            Console.WriteLine();
            for (int e = 0; e < arr.GetLength(1); e++)
            {
                Console.Write((e == 0) ? " |" : $"{b[e - 1]}|");
                for (int r = 0; r < arr.GetLength(0); r++)
                {
                    Console.Write($"{arr[r,e]} ");
                }
                Console.WriteLine();
            }
            return arr[a.Length-1, b.Length-1];
        }
    }
}
