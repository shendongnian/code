    public static void main(string[] args) {
        var greeter = new Greeter(args.FirstOrDefault());
        Console.WriteLine(greeter.SayHello());
        Console.WriteLine(greeter.SayGoodBye());
    }
