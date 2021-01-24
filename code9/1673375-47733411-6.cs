    public void AddSomeKeys(params KeyValuePair<string, object>[] arguments) {
        foreach (var item in arguments){
            Console.WriteLine($"key: {item.Key} value: {item.Value}");
        }
    }
