    public static void TestLists()
    {
        List<List<string>> lists = new List<List<string>> { new List<string>{"1", "10", "Red"},new List<string>{"6", "34", "Black"},new List<string>{"2", "19", "Yellow"}};
        foreach (var aList in lists)
        {
            var p = new ListParser(aList);
            if (p.IsValid)
            {
                if (p.x == 6 && p.y == 34)
                {
                    Console.WriteLine($"Found desired list: x={p.x}, y={p.y}, Value={p.value}");
                }
                else
                {
                    Console.WriteLine($"Found another list: x={p.x}, y={p.y}, Value={p.value}");
                }
            }
        }
        Console.ReadLine();
    }
