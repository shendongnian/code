using System;
namespace Using_methods_to_reverse_an_array
{
    class Program
    {
        static int[] CreateArray()
        {
            int[] array = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            return array;
        }
        static void PrintNumbers(int[] array)
        {
            foreach (int numbers in array )
            {
                Console.WriteLine(numbers);
            }
        }
        static void ReverseNumbers(int[] array)
        {
            for (int i = 0; i < array.Length/2; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
            
        }
        static void Main(string[] args)
        {
            int[] numbers = CreateArray();
            ReverseNumbers(numbers);
            PrintNumbers(numbers);
            Console.ReadLine();
        }
    }
}
