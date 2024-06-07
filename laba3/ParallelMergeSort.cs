using System;
using System.Threading.Tasks;

namespace ParallelMergeSort
{
    public class ParallelMergeSort
    {
        public static void Sort(int[] array, int depth = 0)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];

            Array.Copy(array, 0, left, 0, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            if (depth < Environment.ProcessorCount)
            {
                Parallel.Invoke(
                    () => Sort(left, depth + 1),
                    () => Sort(right, depth + 1)
                );
            }
            else
            {
                Sort(left, depth + 1);
                Sort(right, depth + 1);
            }

            Merge(array, left, right);
        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int leftIndex = 0, rightIndex = 0, arrayIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] <= right[rightIndex])
                {
                    array[arrayIndex++] = left[leftIndex++];
                }
                else
                {
                    array[arrayIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                array[arrayIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                array[arrayIndex++] = right[rightIndex++];
            }
        }
    }
}
