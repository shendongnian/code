    public class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };
            int[] arr2 = { 3, 4 };
            int[] result = new int[size];
            for(int i = 0; i < arr1.Length; i++)
            {
                if(!arr2.Exists(arr1[i]))
                {
                    size++;
                    Array.Resize(ref result, size);
                    result[size - 1] = arr1[i];
                }
            }            
        }
    }
    public static class MyExtensions
    {
        public static bool Exists(this int[] array, int value)
        {
            int[] result = new int[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return true;
            }
            return false;
        }
    }
