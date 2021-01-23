    public delegate double YourDelegate(string param);
    void Main()
    {
        public Dictionary<string, YourDelegate> commands = 
                                            new Dictionary<string, YourDelegate>();
        commands.Add("getdate", GetDate);
        Console.WriteLine("Enter a command");
        string input = Console.ReadLine(); //<-- Try typing "getdate"
        commands[input].Invoke();
    }
    
    public double GetDate(string someParameter)
    {
       Console.WriteLine(DateTime.Today);
       return 0.0;
    }
