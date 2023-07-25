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
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int PivotIndex = Partition(array, left, right);
                QuickSort(array, left, PivotIndex - 1);
                QuickSort(array, PivotIndex + 1, right);
            }
        }
        public static int Partition(int[] array, int left, int right)
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
        public static void Swap(int[] array, int i, int j)
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
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers for Quick Sort");

            int[] arr = new int[7];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());

            }
            Console.Write("Numbers are :");
            Print(arr);

            Console.WriteLine("Before Sorting");
            Print(arr);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(arr);
            sw.Stop();

            Console.WriteLine("After Quick Sort");
            Print(arr);
            Console.WriteLine($"Array Size {arr.Length} Time taken {sw.Elapsed.TotalMilliseconds} milliSeconds");
            Console.ReadKey();
        }
    }
}