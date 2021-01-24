    public void Main()
    {
        MyMethod("argument1", "argument2", "...");
    }
    public string MyMethod(params string[] parameters)
    {
        foreach (var parameter in parameters)
        {
            Console.Write(parameter);
        }
    }
