using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3_alebastr
{
    delegate long mySortDelegate(ref int[] a); 

    class Program
    {
        static void Main(string[] args)
        {
            int n = 50000;
            Random r = new Random();
            int[] a = new int[n];
            int[] b = new int[n];
            int[] c = new int[n];
            int[] d = new int[n];
            int[] e = new int[n];

            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] = b[i] = c[i] = d[i] = e[i] = r.Next();
                }
                Sort(BubbleSort, ref a);
                Sort(BubbleSortOpt, ref b);
                Sort(ShakerSort, ref c);
                Sort(MinMaxSort, ref d);
                Sort(InsertsSort, ref e);
            }
            Console.ReadKey();
            return;
            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.Write("Элемент для поиска:");
            Console.WriteLine($"Индекс элемента в массиве: {BinarySearch(ref a, int.Parse(Console.ReadLine()))}");
            //foreach (var item in b)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();
            //foreach (var item in c)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();
            //foreach (var item in e)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();
            Console.ReadKey();
        }
        static int BinarySearch(ref int[] mas, int num)
        {
            int left = 0, right = mas.Length - 1;
            int m = left + (right-left)/2;
            while (left <= right)
            {
                if (mas[m] == num) return m;
                else if (mas[m] < num)
                {
                    left = m + 1;
                }
                else
                {
                    right = m - 1;
                }
                m = left + (right - left) / 2;
            }
            return -1;
        }

        static void Sort(mySortDelegate del, ref int[] mas)
        {
            long count = 0;
            DateTime time = DateTime.Now;
            count = del(ref mas);
            TimeSpan interval = DateTime.Now - time;
            Console.WriteLine($"{del.Method.ToString(),-35}: время {interval.TotalMilliseconds,10} ms, операций {count}");
        }

        static long BubbleSort(ref int[] mas)
        {
            long count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                count++;
                for (int j = 0; j < mas.Length-1; j++)
                {
                    count++;
                    if (mas[j] > mas[j + 1])
                    {
                        swap(ref mas[j], ref mas[j + 1]);
                        
                    }
                }
            }
            return count;
        }

        static long BubbleSortOpt(ref int[] mas)
        {
            long count = 0;
            bool f;
            for (int i = 0; i < mas.Length; i++)
            {
                f = true;
                count++;
                for (int j = 0; j < mas.Length - 1; j++)
                {
                    count++;
                    if (mas[j] > mas[j + 1])
                    {
                        swap(ref mas[j], ref mas[j + 1]);
                        
                        f = false;
                    }
                }
                if (f) break;
            }
            return count;
        }

        static long ShakerSort(ref int[] mas)
        {
            int imin = 1;
            int imax = mas.Length-1;
            int i=0;
            long count = 0;
            bool dir = true;
            bool flag = true;
            while (true)
            {
                if (dir)
                {
                    if (mas[i] > mas[i + 1])
                    {
                        swap(ref mas[i], ref mas[i + 1]);
                        flag = false;
                    }
                    i++;
                } else
                {
                    if (mas[i] < mas[i - 1])
                    {
                        swap(ref mas[i], ref mas[i - 1]);
                        flag = false;
                    }
                    i--;
                }
                if (i == imax)
                {
                    if (flag) break;
                    else flag = true;
                    dir = !dir;
                    imax--;
                    i--;
                } 
                else if (i < imin)
                {
                    if (flag) break;
                    else flag = true;
                    dir = !dir;
                    imin++;
                    i++;
                }
                if (imax == imin) break;
                count++;
            }
            return count;
        }

        static long MinMaxSort(ref int[] mas)
        {
            long count = 0;
            int j = 0;
            int jmin;
            for (int i = 0; i < mas.Length; i++)
            {
                count++;
                jmin = i;
                for (j = i + 1; j < mas.Length; j++)
                {
                    count++;
                    if (mas[j] < mas[jmin])
                    {
                        jmin = j;
                    }
                }
                swap(ref mas[i], ref mas[jmin]);
            }
            return count;
        }

        static long InsertsSort(ref int[] mas)
        {
            long count = 0;
            int j;
            int temp;
            for (int i = 1; i < mas.Length; i++)
            {
                temp = mas[i];
                j = i;
                count++;
                while (j > 0 && mas[j - 1] > temp)
                {
                    swap(ref mas[j], ref mas[j - 1]);
                    j--;
                    count++;
                }
            }
            return count;
        }

        static void swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
