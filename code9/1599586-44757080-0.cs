    static void Main(string[] args)
    {
        int outcome = 1;
        int removed;
        List<int> list = new List<int>(new int[] { 1, 2, 6, 4, 6, 4, 9, 
    8, 3, 1 });
        for (int j = 0; j < 9; j++)
        {
            removed = list[j];
            list.RemoveAt(j);
            for (int i = 0; i < list.Count; i++)
            {
                outcome *= list[i];
            }
            list.Add(removed);
            Console.WriteLine(outcome);
        }
        Console.ReadKey();
    }
