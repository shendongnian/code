    public static void Main()
    {
        int[] arr1 = { 1, 4, 5 };
        Console.WriteLine("{0}", arr1[0]);
        ModifyArray(ref arr1);
        Console.WriteLine("{0}", arr1[0]);
    }
    static void ModifyArray(ref int[] arr1)
    {
        arr1[0] = 20;
        arr1 = new int[5] { -3, -1, -2, -3, -4 };
        Console.WriteLine("{0}", arr1[0]);
    }
