using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12Assignment15
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partitioner(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partitioner(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        //Merge Sort
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);

        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Enter numbers for Quick Sort");


            int[] array1 = new int[7];
            for (int i = 0; i < array1.Length; i++)
            {
                array1[i] = int.Parse(Console.ReadLine());

            }
            Console.Write("Numbers are :");
            Print(array1);

            //Quick Sorting
            Console.WriteLine("Quick sort Before Sorting:");
            Print(array1);

            Console.WriteLine("After Quick Sort:");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            QuickSort(array1);
            stopwatch1.Stop();
            Print(array1);

            Console.WriteLine($"Array {array1.Length} Time Taken for Quick Sort is {stopwatch1.Elapsed.TotalMilliseconds} milliseconds\n");
            Console.WriteLine("-----------------------------------------------");

            //Merge Sorting
            Console.WriteLine("Enter Numbers for Merge Sort");
            int[] array2 = new int[7];
            for (int i = 0; i < array2.Length; i++)
            {
                array2[i] = int.Parse(Console.ReadLine());

            }
            Console.Write("Numbers are :");
            Print(array2);

            Console.WriteLine("Merge Sort Before Sorting: ");
            Print(array2);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            MergeSort(array2);
            stopwatch2.Stop();
            Console.WriteLine("\nMerge Sorted Array: ");
            Print(array2);

            Console.WriteLine($"\nArray {array1.Length} Time Taken for Merge Sort is {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();

        }
    }
}