    public class Program
    {
        static void Main(string[] args)
        {
            int resultLength = 0;
            int[] arr1 = { 1, 2, 3, 4, 5, 6 };
            int[] arr2 = { 3, 4 };
            int[] result = new int[resultLength];
            for(int i = 0; i < arr1.Length; i++)
            {
                if(!arr2.Exists(arr1[i]))
                {
                    resultLength++;
                    Array.Resize(ref result, resultLength);
                    result[resultLength- 1] = arr1[i];
                }
            }            
        }
    }
    public static class MyExtensions
    {
        public static bool Exists(this int[] array, int value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    return true;
            }
            return false;
        }
    }
