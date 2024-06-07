using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public class ConcurrentMergeSort : ISortAlgorithm
    {
        public void Sort(int[] array)
        {
            ParallelMergeSort.Sort(array);
        }
    }
}
