    static void Main(string[] args)
    {
        int num = 0;
        Write("How many grades are you wanting to process...");
        num = Convert.ToInt32(Console.ReadLine());
        int[] grades = new int[num];
        for (int i = 0; i < num; i++)
        {
            Console.Write("Enter grade:");
            grades[i] = Convert.ToInt32(Console.ReadLine());
        }
    }
