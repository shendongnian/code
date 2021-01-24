    public void AddSomeKeys(params (string, object)[] arguments) {
        foreach (var item in arguments){
            Console.WriteLine($"key: {item.Item1} value: {item.Item2}");
        }
    }
