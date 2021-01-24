    public void AddSomeKeys(params (string, string)[] arguments) {
        foreach (var item in arguments){
            Console.WriteLine("key: " + item.Item1 + " value: " + item.Item2);
        }
    }
