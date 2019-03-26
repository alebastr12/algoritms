using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alebastr_lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Деление
            uint a, b;
            Console.Write("Делимое:");
            a = uint.Parse(Console.ReadLine());
            Console.Write("Делитель:");
            b = uint.Parse(Console.ReadLine());
            uint rem;
            Console.WriteLine($"Частное: {div(a, b, out rem)} Остаток: {rem}");
            Console.ReadKey();
            #endregion
            #region Нечетные цифры в числе
            Console.Write("Число: ");
            Console.WriteLine($"{IsOddDigit(uint.Parse(Console.ReadLine()))}");
            Console.ReadKey();
            #endregion
            #region среднее арифметическое всех положительных чётных чисел, оканчивающихся на 8
            int num,sum=0;
            int j = 0;
            Console.WriteLine($"Вводите числа, 0 - конец.");
            while (true)
            {
                num = int.Parse(Console.ReadLine());
                if (num == 0) break;
                if ((num > 0) & (num % 10 == 8)) //больше 0 и оканчиваются на 8 (четность проверять не надо)
                {
                    sum += num;
                    j++;
                }
            }
            Console.WriteLine($"Сумма = {sum/j}");
            Console.ReadKey();
            #endregion
            #region ГПСЧ
            Random rnd = new Random();
            x = (ulong)DateTime.Now.Ticks;
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{rnd.Next(100),5} {rand()%100,5}");
            }
            #endregion
            #region Поиск автоморфных чисел
            Console.Write("Введите натуральное число: ");
            uint N = uint.Parse(Console.ReadLine());
            Console.WriteLine($"Автоморфные числа от 0 до {N}");
            for (uint i = 0; i <= N; i++)
            {
                if (IsAutoMorf(i))
                    Console.WriteLine($"Число: {i,-10} квадрат: {(ulong)i*i,-20}");
            }
            Console.WriteLine("Любую клавишу для выхода.");
            Console.ReadKey();
            #endregion
        }
        /// <summary>
        /// Метод деления а на b
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <param name="remaid">Остаток от деления</param>
        /// <returns>Частное от деления</returns>
        static uint div(uint a, uint b, out uint remaid)
        {
            uint result=0;
            while (a > b)
            {
                a = a - b;
                result++;
            }
            remaid = a;
            return result;
        }
        /// <summary>
        /// метод ищет нечетные цифры в числе
        /// </summary>
        /// <param name="num">Число</param>
        /// <returns>Возвращает true, если есть хотя бы одна нечетная цифра</returns>
        static bool IsOddDigit(uint num)
        {
            while (num > 0)
            {
                if ((num % 10) % 2 == 1) return true;
                num = num / 10;
            }
            return false;
        }
        #region максимальное из 3
        /// <summary>
        /// Максимальное из трех...
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="c">Иретье число</param>
        /// <returns>Максимальное</returns>
        static int MaxOf(int a, int b, int c)
        {
            if (a > b)
            {
                return (a > c) ? a :c;
            }
            else
            {
                return (b > c) ? b : c;
            }
        }
        #endregion
        static ulong x = 3456789; //Исходные данные для ГПСЧ
        static ulong y = 62436069;
        static ulong z = 1288629;
        static ulong w = 675123;
        /// <summary>
        /// Расчет случайного числа по Xorshift
        /// </summary>
        /// <returns></returns>
        static ulong rand()
        {
            ulong t;
            t = (x ^ (x << 11)); x = y; y = z; z = w;
            return (w = (w ^ (w >> 19)) ^ (t ^ (t >> 8)));
        }
        /// <summary>
        /// Определяет является ли число автоморфным
        /// </summary>
        /// <param name="num">Число</param>
        /// <returns>истина, если является, иначе ложь</returns>
        static bool IsAutoMorf(uint num)
        {
            if (num == 0 || num == 1) return true;       //Чтобы немного ускорить расчет
            uint modDivTen = num % 10;
            if (modDivTen == 5 || modDivTen == 6)
            {
                ulong k = digits(num);                   //Основной алгоритм
                ulong pow2 = (ulong)num * (ulong)num;
                if (pow2 % k == num)
                    return true;
                else return false;
            }
            else return false;
        }
        /// <summary>
        /// Округляет значение до 10*n. Используется для выделения
        /// остатка из квадрата числа.
        /// </summary>
        /// <param name="i">Значение</param>
        /// <returns>Результат</returns>
        static ulong digits(uint i)
        {
            ulong k = 1;
            while (i > 0)
            {
                i = i / 10;
                k*=10;
            }
            return k;
        }
    }
}
