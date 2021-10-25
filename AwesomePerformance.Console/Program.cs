using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AwesomePerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            HashSet<int> hashSetPool = new HashSet<int>(GenerateNumbers(100000, 1));
            int[] sequence = GenerateNumbers(100000, 2);

            sw.Start();

            for (int i = 0; i < 100000; i++)
            {
                bool contains = PoolManager.Contains(hashSetPool, sequence);
            }

            sw.Stop();

            Console.WriteLine("HashSet pool milliseconds: " + sw.ElapsedMilliseconds);

            int[] pool = GenerateNumbers(100000, 1);

            sw.Start();

            for (int i = 0; i < 100000; i++)
            {
                bool contains = PoolManager.Contains(pool, sequence);
            }

            sw.Stop();

            Console.WriteLine("Array pool milliseconds: " + sw.ElapsedMilliseconds);
        }

        public static int[] GenerateNumbers(int size, int? seed = null)
        {
            int[] number = new int[size];
            Random random = seed != null ? new Random(seed.Value) : new Random();

            for (int i = 0; i < number.Length; i++)
            {
                number[i] = random.Next(0, int.MaxValue);
            }

            return number;
        }
    }
}
