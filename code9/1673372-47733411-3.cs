    public void AddSomeKeys(params KeyValuePair<string, string>[] arguments) {
        foreach (var item in arguments){
            Console.WriteLine("key: " + item.Key + " value: " + item.Value);
        }
    }
