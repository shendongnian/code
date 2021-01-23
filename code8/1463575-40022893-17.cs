    static void Main(string[] args)
    {
        object[] parameters = new object[] { "false", true };
        typeof(Program).GetMethod("Convert")
        // Be sure that the types will create a valid key
            .MakeGenericMethod(new Type[] { parameters[0].GetType(), parameters[1].GetType() })
        // Change null to your instance
        // if you are not calling a static method
            .Invoke(null, parameters);
        // parameters[1] is an out parameter
        // then you can get its value like that
        Console.WriteLine(parameters[1]);
        Console.ReadKey();
    }
