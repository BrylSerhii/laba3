using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    public class SequentialMergeSort : ISortAlgorithm
    {
        public void Sort(int[] array)
        {
            MergeSort.Sort(array);
        }
    }
}
