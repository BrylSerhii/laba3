using System;
using System.Diagnostics;

namespace ParallelMergeSort
{
    public class PerformanceTest
    {
        public static void MeasurePerformance()
        {
            int[] sizes = { 1000, 10000, 100000, 1000000 };
            foreach (var size in sizes)
            {
                int[] array = new int[size];
                Random rand = new Random();
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(size);
                }

                int[] arrayCopy1 = (int[])array.Clone();
                int[] arrayCopy2 = (int[])array.Clone();

                Stopwatch sw = new Stopwatch();

                sw.Start();
                MergeSort.Sort(arrayCopy1);
                sw.Stop();
                Console.WriteLine($"Sequential Sort of {size} elements: {sw.ElapsedMilliseconds} ms");

                sw.Restart();
                ParallelMergeSort.Sort(arrayCopy2);
                sw.Stop();
                Console.WriteLine($"Parallel Sort of {size} elements: {sw.ElapsedMilliseconds} ms");

                Console.WriteLine();
            }
        }
    }
}
