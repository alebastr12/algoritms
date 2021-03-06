﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание 3 Определить, сколько существует программ, которые преобразуют число 3 в число 20
            //R(n)=R(n-1)+R(n/2)
            //*2, +1
            //from 3 to 20
            const int a0 = 3;
            const int a1 = 20;
            int[] array = new int[a1 + 1];
            int i=a0;
            array[a0] = 1;
            while(i < a1){
                i++;
                if (i % 2 != 0) array[i] = array[i - 1];
                else array[i] = array[i - 1] + array[i / 2];
            }
            for (int j = 0; j < a1+1; j++)
            {
                Console.WriteLine($"{j} {array[j]}");
            }
            Console.WriteLine($"От {a0} до {ф1} - {array[i]} программ");
            Console.WriteLine($"Рекурсивный метод - {progs(a0, a1)}");
            Console.ReadKey();
            #endregion

            #region Задание 2 Возведение в степень
            int num, st;
            Console.Write("Число:");
            num= int.Parse(Console.ReadLine());
            Console.Write("Степень:");
            st= int.Parse(Console.ReadLine());
            Console.WriteLine($"{Pow(num, st),-8} {PowRec(num, st),-8} {QuickPowRec(num,st),-8}");
            Console.ReadKey();
            #endregion

            #region Задание 1 Dec to Bun
            int a;
            Console.Write("Число:");
            a=int.Parse(Console.ReadLine());
            Console.Write($"Двоичное представление: {ToBin(a)}");
            Console.ReadKey();
            #endregion
        }
        /// <summary>
        /// Рекурсивный метод определения количества программ для преобразования из числа a в b
        /// </summary>
        /// <param name="a">Число а</param>
        /// <param name="b">Число b</param>
        /// <returns>Количество программ</returns>
        static int progs(int a, int b)
        {
            if (b == a) return 1;
            else if (b < a) return 0;
            else if (b % 2 != 0) return progs(a, b - 1);
            else return progs(a, b - 1) + progs(a, b / 2);
        }
        /// <summary>
        /// Функция перевода из 10-чного представления в двоичное
        /// </summary>
        /// <param name="a">Десятичное число</param>
        /// <returns>Двоичное число</returns>
        static int ToBin(int a)
        {
            if (a == 0)
            {
                return 0;
            }
            else
            {
                return 10*ToBin(a / 2) + a % 2;
            }
        }
        /// <summary>
        /// Возведение в степень без рекурсии
        /// </summary>
        /// <param name="a">число</param>
        /// <param name="b">степень</param>
        /// <returns>результат</returns>
        static long Pow(int a, int b)
        {
            long res = 1;
            while (b > 0)
            {
                res = res * a;
                b--;
            }
            return res;
        }
        /// <summary>
        /// Рекурсивное возведение в степень
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="b">Степень</param>
        /// <returns>Результат</returns>
        static long PowRec(int a, int b)
        {
            if (b == 0) return 1;
            else return a * PowRec(a, b - 1);
        }
        /// <summary>
        /// Рекурсивное возведение в степень с использованием четности степени
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="b">Степень</param>
        /// <returns>Результат</returns>
        static long QuickPowRec(int a, int b)
        {
            if (b == 0) return 1;
            else if(b%2==1) return a * QuickPowRec(a, b - 1);
            else
            {
                long c = QuickPowRec(a, b / 2);
                return c * c;
            }
        }
    }
}
