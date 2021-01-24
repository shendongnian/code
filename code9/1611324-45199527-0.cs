        var sentence = Console.ReadLine();
        string input = sentence;
        string[] sentenses = input.Split(' ');
        StringBuilder s = new StringBuilder();
        foreach(var sent in sentenses) {                
       s.Append(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(sent));
        }
        Console.WriteLine(s.ToString());
        Console.WriteLine("  ");
