    static void Main(string[] args)
    {
        Func("cacten","ace");
        Func("cacten", "aced");
        Console.ReadLine();
    }
    
    static void Func(string input, string word)
    {
        bool isMatch = true;
        foreach (Char s in word)
        {
            if (!input.Contains(s.ToString()))
            {
               
                isMatch = false;
                break;
            }
        }
    
        // success
        if (isMatch)
        {
            Console.WriteLine(word);
        }
        // no match
        else
        {
            Console.WriteLine("No Match");
        }
                  
    }
