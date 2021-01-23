    void Main()
    {
        public Dictionary<string, Action<string>> commands = new Dictionary<string, Action>();
        commands.Add("getdate", GetDate);
        Console.WriteLine("Enter a command");
        string input = Console.ReadLine(); //<-- Try typing "getdate"
        commands[input].Invoke();
    }
    
    public void GetDate(string someParameter)
    {
       Console.WriteLine(DateTime.Today);
    }
