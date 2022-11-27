using System;
using System.Threading;

namespace ConsoleApp1
{


    class Program
    {
        public static int N;
        public static int n;
        public static int b;
        public static int[] returns;
        public static int[] C;
        public static int i;
        static void Main(string[] args)

        {
            Console.WriteLine("Введите кол-во элементов");
            N = ReadNumber();
            Console.WriteLine("Введите кол-во потоков");
            n = ReadNumber();
            Console.WriteLine("Введите число b");
            b = ReadNumber();
            C = new int[N];
            Random rng = new Random();
            for (i = 0; i < N; i++)
            {
                C[i] = rng.Next(1, 100+b+1);
            }
            Thread[] thread = new Thread[n];
            returns = new int[n];
            int rezult = 0;
            int s = 0;
            for (i = 0; i < n; i++)
            {
                int tmp = i;
                returns[tmp] = 0;
                thread[i] = new Thread(() => { returns[tmp] = ThreadFunc(tmp); });
                thread[i].Start();
            }

            for (i = 0; i < n; i++)
            {
                thread[i].Join();
                rezult += returns[i];
            }
            Console.WriteLine($"Количесвто встреч элемента b в массиве C: {rezult}");
            Console.ReadLine();
        }
        static int ThreadFunc(int number)
        {
            int i, nbr, begin, part, end;
            int sum = 0;
            nbr = number;
            part = N / n;
            begin = part * nbr; end = begin + part;

            if (nbr == n - 1) end = N;

            for (i = begin; i < end; i++)
            {
                if (C[i] == b)
                {
                    sum ++;
                }
            }
            return sum;
        }
        public static int ReadNumber()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || !(result > 0))
            {
                Console.WriteLine("Введите число");
            }
            return result;
        }
    }
}
