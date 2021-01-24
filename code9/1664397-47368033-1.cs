    IEnumerable<int> GetNumbers()
    {
        while (true)
        {
             try
             {
                 Console.Write("Enter a number: ");
                 var text = Console.ReadLine();
                 var value = int.Parse(text);
                 yield return value;
             }
             catch (Exception ex)
             {
                 Console.WriteLine("That'a not a number!");
             }
        }
    }
