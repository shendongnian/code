    public void AddSomeKeys(params (string key, object value)[] arguments) {
        foreach (var item in arguments){
            Console.WriteLine($"key: {item.key} value: {item.value}");
        }
    }
