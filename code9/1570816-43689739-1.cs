    static void Main()
    {
        int[] deltas= { 3,2,1,3,1,2,3 };
        
        int number = 30;
        
        List<int> result = new List<int>();
        
        int j = 1;
        for(int i = deltas[0]; i<=number; i+=deltas[j++%deltas.Length])
        {
            result.Add(i);
        }
        
        foreach(int i in result)
            Console.Write(i+", ");
    }
