    static void DrawGraph(int[] array)
    {
        int maxElementValue = 0;
        foreach (int i in array)
        {
            if (i > maxElementValue) maxElementValue = i;
        }
        
        for (int rowIndex= 0; rowIndex < maxElementValue; ++rowIndex)
        {
            foreach (int i in array)
            {
                Console.Write((i < rowIndex - columnIndex ? 0 : 1) + " ");
            }
            
            Console.WriteLine();
        }
    }
