    void Main()
    {
        public Dictionary<string, Func<string, int>> commands =
                                       new Dictionary<string, Func<string, int>>();
        commands.Add("getdate", GetDate);
        Console.WriteLine("Enter a command");
        string input = Console.ReadLine(); //<-- Try typing "getdate"
        commands[input].Invoke();
    }
    
    public int GetDate(string someParameter)
    {
       Console.WriteLine(DateTime.Today);
       return 0;
    }
