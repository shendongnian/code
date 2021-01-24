    class SomeFunctionParams
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
    public static void someFunction(SomeFunctionParams params)
    {
        Console.WriteLine("Number={0}", params.Number);
        Console.WriteLine("Text={0}", params.Text);
    }
