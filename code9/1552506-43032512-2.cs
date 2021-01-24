    static void Main(string[] args)
    {
        int num = 0;
        Write("How many grades are you wanting to process...");
        num = Convert.ToInt32(Console.ReadLine());
        Double[] grades = new Double[num];
        for (int i = 0; i < num; i++)
        {
            Console.Write("Enter grade:");
            grades[i] = Convert.ToDouble(Console.ReadLine());
        }
    }
    
