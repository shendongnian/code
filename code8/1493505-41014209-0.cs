    static void Main(string[] args)
    {
        List<int> players = new List<int> { 1, 2, 3, 5, 8, 9, 10 };
        for (int i = 1; i < 5; i++)
        {
            Console.WriteLine("Round Nr: " + i);
            //rotate the List, shift dealer from first to last position
            int dealer = players.First();
            players.Remove(dealer);
            players.Add(dealer);
            Console.WriteLine("order of moving:");
            Console.WriteLine(String.Join(" > ", players));
        }
        Console.ReadKey();
    }
