        using System;
        using System.Collections.Generic;
        using System.Threading;
       
       namespace Test1
         {
                class Program
       {
        static void Main(string[] args)
        {
            MySorter();
        }
        static void MySorter()
        {
            int[] data = MyArray();
            Console.WriteLine();
            Console.WriteLine("Chose 1 to sort Ascending or 2 to sort Descending:");
            //int choice = Console.Read();
            ConsoleKeyInfo choice = Console.ReadKey();
            Console.WriteLine();
            if (choice.Key == ConsoleKey.D1 || choice.Key == ConsoleKey.NumPad1)
            {
                QuickSort(data);
                string result = string.Join(", ", data);
                Console.WriteLine(result);
                Thread.Sleep(4000);
            }
            else if (choice.Key == ConsoleKey.D2 || choice.Key == ConsoleKey.NumPad2)
            {
                QuickSort(data, Comparer<int>.Create((a, b) => b.CompareTo(a)));
                Console.WriteLine(string.Join(", ", data));
                Thread.Sleep(4000);
            }
            else
            {
                Console.WriteLine("wrong input.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        public static int[] MyArray()
        {
            Console.WriteLine("Enter a total of 10 numbers to be sorted: ");
            int[] InputData = new int[10];
            for (int i = 0; i < InputData.Length; i++)
            {
                var pressedkey = Console.ReadKey();
                int number;
                bool result = int.TryParse(pressedkey.KeyChar.ToString(), out number);
                if (result)
                {
                    InputData[i] = number;
                }
            }
            return InputData;
        }
        public static void QuickSort<T>(T[] data)
        {
            Quick_Sort(data, 0, data.Length - 1, Comparer<T>.Default);
        }
        public static void QuickSort<T>(T[] data, IComparer<T> comparer)
        {
            Quick_Sort(data, 0, data.Length - 1, comparer);
        }
        public static void Quick_Sort<T>(T[] data, int left, int right, IComparer<T> comparer)
        {
            int i, j;
            T pivot, temp;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((comparer.Compare(data[i], pivot) < 0) && (i < right)) i++;
                while ((comparer.Compare(pivot, data[j]) < 0) && (j > left)) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (left < j) Quick_Sort(data, left, j, comparer);
            if (i < right) Quick_Sort(data, i, right, comparer);
         }
 
         }
        }
