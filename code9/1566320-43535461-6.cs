    static void Main(string[] args)
    {
        try
        {
            int[] array = new int[] { 1, 5, 3, 4, 2 };
            //Reverse copy of Array
            var newarr = arrayReverseNewArray(array);
            //Display New Array Elements
            foreach (int x in newarr)
                Console.Write(x + ",");
            Console.WriteLine("");
            //Reverse original Array
            arrayReverseinPlace(array);
            //Display original Array Elements
            foreach (int x in array)
                Console.Write(x + ",");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private static void arrayReverseinPlace(int[] array)
    {
        for (int i = 0; i < array.Length / 2; i++)
        {
            int tempvar = array[i];
            array[i] = array[array.Length - i - 1];
            array[array.Length - i - 1] = tempvar;
        }
    }
    private static int[] arrayReverseNewArray(int[] array)
    {
        int[] arr = new int[array.Length];
        int j = 0;
        for (int i = array.Length - 1; i >=0 ; i--)
        {
            arr[j] = array[i];
            j++;
        }
        return arr;
    }
