    static ref int GetAnswer(int[] arr)
    {
        return ref arr[0];
    }
    static void Main()
    {
        int i = 0;
        int[] j = new int[] { 42 };
        i = A.GetAnswer(j);
        System.Console.WriteLine(i);
    }
