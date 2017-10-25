using System;
using System.Collections.Generic;

namespace Playground
{
    public class Program
    {
        private static int swapCounts = 0;
        public static List<int> QuickSort(List<int> toSort)
        {
            QuickSortList(toSort, 0, toSort.Count - 1);
            return toSort;
        }

        private static void QuickSortList(List<int> toSort, int leftIndex, int rightIndex)
        {
            //0 -element array
            if (rightIndex == leftIndex) return;
            
            var pivotIndex = ChoosePivot(leftIndex, rightIndex);
            var pivotValue = toSort[pivotIndex];

            var sortedIndex = QuickSortDivide(toSort, leftIndex, rightIndex, pivotValue);
            if (sortedIndex > leftIndex + 1)
            {
                QuickSortList(toSort, leftIndex, sortedIndex - 1);
            }

            if (sortedIndex < rightIndex - 1)
            {
                QuickSortList(toSort, sortedIndex + 1, rightIndex);
            }

        }

        private static int QuickSortDivide(List<int> toSort, int leftIndex, int rightIndex, int pivotValue)
        {
            while (leftIndex < rightIndex)
            {
                // Get Left one
                while (toSort[leftIndex] < pivotValue)
                {
                    ++leftIndex;
                }
                if (leftIndex >= rightIndex) break;

                while (toSort[rightIndex] > pivotValue)
                {
                    --rightIndex;
                }
                if (leftIndex >= rightIndex) break;

                if (toSort[leftIndex] == toSort[rightIndex])
                {
                    ++leftIndex;
                    continue;
                }
                Swap(toSort, leftIndex, rightIndex);
            }

            return leftIndex;
        }

        private static void Swap(List<int> toSort, int indexA, int indexB)
        {
            var temp = toSort[indexA];
            toSort[indexA] = toSort[indexB];
            toSort[indexB] = temp;
            ++swapCounts;
        }

        private static int ChoosePivot(int start, int end)
        {
            // Choose pivot in the middle
            if (end - start <= 0)
            {
                throw new Exception("Cannot choose pivot on empty list");
            }
            return start + (end - start) / 2;
        }


        private static void PringList(List<int> toPrint)
        {
            Console.WriteLine($"For list with length={toPrint.Count} it took {swapCounts} swaps to sort. Sorted list:");

            if (toPrint.Count < 10)
            {
                foreach (var element in toPrint)
                {
                    Console.Write($"{element}, ");
                }
                Console.WriteLine();  
            }
            
            //Test correctness
            List<int> systemSorted = new List<int>(toPrint);
            systemSorted.Sort();
            for(var i = 0; i< toPrint.Count; ++i)
            {
                if (systemSorted[i] != toPrint[i])
                {
                    Console.WriteLine($"ERROR on number {i} element");
                }
            }
        }

        private static List<int> GenerateList(int length)
        {
            var randomGenerator = new Random();
            var list = new List<int>(length);
            for (var i = 0; i < length; ++i)
            {
                list.Add(randomGenerator.Next());
            }
            return list;
        }
        
        public static void Main(string[] args)
        {
   
            PringList(QuickSort(new List<int>
            {
                4,
                3,
                5,
                2,
                1
            }));
            swapCounts = 0;
            
            PringList(QuickSort(new List<int>
            {
                2,
                3,
                5,
                4,
                2
            }));
            swapCounts = 0;
            
            PringList(QuickSort(new List<int>
            {
                2,2,3,4,5,4,3,4,5,3,2,3,2,3,4,5,6,7,8,9,6,7,6,8,7,6,7,8,9,0,3,5,4,6,7,8,6,5,
                3,
                5,
                4,
                2
            }));
            swapCounts = 0;
            
            
            PringList(QuickSort(GenerateList(5)));
            PringList(QuickSort(GenerateList(50)));
            PringList(QuickSort(GenerateList(500)));
            PringList(QuickSort(GenerateList(5000)));
            PringList(QuickSort(GenerateList(50000)));
            PringList(QuickSort(GenerateList(500000)));
        }
    }
}