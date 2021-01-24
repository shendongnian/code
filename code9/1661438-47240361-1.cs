    static void Main(string[] args)
    {
        int num;
        string getNum;
        getNum = Console.ReadLine();
        num = Int32.Parse(getNum);
        int[] array = Array(num); // Change this to call the Arrra(int num) method
        Console.WriteLine("Array created with {0} elements.",num);
    }
