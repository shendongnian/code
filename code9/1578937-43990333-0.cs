    public static async Task<string> Foo()
    {
        Console.WriteLine("In Foo");
        await Task.Yield();
        Console.WriteLine("I'm Back");
        return "Foo";
    }
    
    
    static void Main(string[] args)
    {
        var t = new Task(async () =>
        {
            Console.WriteLine("Start");
            var f = Foo();
            Console.WriteLine("After Foo");        
            var r = await f;
            Console.WriteLine(r);
        });
        t.RunSynchronously();
    }
