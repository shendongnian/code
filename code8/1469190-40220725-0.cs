    static void Main(string[] args)
    {
        int totalOnes = 0;
        int totalZeroes = 0;
    
        while (true)
        {
            int ret = Here();
            if (ret == 1) totalOnes++; else totalZeroes++;
            Console.WriteLine(ret);  
        }
        Console.WriteLine("Total Ones: {0} Total Zeroes: {1}", totalOnes, totalZeroes);
    }
