    public static string ExtensionMethod(this string format, object args)
    {
        return format + args.ToString();
    }
    private static void Main()
    {
        string test = "hello ";
        object d = new { World = "world" };
        // Error CS1973  'string' has no applicable method named 'ExtensionMethod'
        //                but appears to have an extension method by that name. 
        //               Extension methods cannot be dynamically dispatched. 
        //               Consider casting the dynamic arguments or calling
        //               the extension method without the extension method syntax.
        var result = test.ExtensionMethod(d);
        // this syntax works fine
        var result2 = Program.ExtensionMethod(test, d);
        // for whatever reason, this works, too!
        var result3 = test.ExtensionMethod((object)d);
        // even this works...
        var result4 = test.ExtensionMethod(new { World = "world" });
        Console.WriteLine(result);
        Console.ReadLine();
    }
