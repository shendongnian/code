    static void Main(string[] args)
    {
        string str = "Hello You are welcome";
        foreach (var item in str.Split(' ')) // split the string (by space)
        {
           if (item == "are")
           {
               Console.WriteLine("True");
           }
       }
    }
