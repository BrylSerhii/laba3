using System;
using laba3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParallelMergeSort.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        private ISortAlgorithm sequentialSorter;
        private ISortAlgorithm parallelSorter;

        [TestInitialize]
        public void Setup()
        {
            sequentialSorter = new SequentialMergeSort();
            parallelSorter = new ConcurrentMergeSort();
        }

        [TestMethod]
        public void TestSequentialSort()
        {
            int[] array = { 5, 3, 8, 6, 2, 7, 4, 1 };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
            sequentialSorter.Sort(array);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void TestParallelSort()
        {
            int[] array = { 5, 3, 8, 6, 2, 7, 4, 1 };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
            parallelSorter.Sort(array);
            CollectionAssert.AreEqual(expected, array);
        }

        [TestMethod]
        public void TestLargeArray()
        {
            int[] array = new int[100000];
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(100000);
            }

            int[] arrayCopy = (int[])array.Clone();
            Array.Sort(arrayCopy);

            parallelSorter.Sort(array);
            CollectionAssert.AreEqual(arrayCopy, array);
        }
    }
}
