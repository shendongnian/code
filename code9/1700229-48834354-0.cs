    static void Main(string[] args)
    {
        string string_ = "one;two;three;four;five;six";
        string[] items = (string_.Split(';'));
        Console.WriteLine("Please select an item to remove:");
        for (int i = 0;i<items.Length;i++)
        {
            Console.WriteLine(string.Format("{0}- {1}", (i + 1).ToString(), items[i]));
        }
        int num = 0;
        int.TryParse(Console.ReadLine(), out num);
        if (num > 0 && num <= items.Length)
        {
            List<string> itemsList = items.ToList();
            itemsList.RemoveAt(num - 1);
            string newString = string.Join(";", itemsList);
            Console.WriteLine(string.Format("The new string is: {0}", newString));
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
        Console.ReadLine();
    }
