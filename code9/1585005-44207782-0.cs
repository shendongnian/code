    static void Main()
    {
        //below is a database call, for sake of code simplicity, I have hardcoded few data samples.
        var states = new List<State>() { 
                new State("CA", "California"),
                new State("NY", "New York"),
                new State("AL", "Alabama"),
                new State("NV", "Nevada")
            };
        var myOrder = new List<string>() { "AL", "NY" };
        var result = myOrder.Join(states, o => o, s => s.Code, (o, s) => s);
        //this outputs - AL NY 
        foreach (var res in result)
        {
            Console.WriteLine(res.Code);
        }
    }
