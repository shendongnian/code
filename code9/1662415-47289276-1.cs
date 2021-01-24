    class SampleClass
    {
        public SampleClass Child { get; set; }
        public SampleClass[] Children { get; set; }
        public string SomeValue { get; set; }
    }
    
    var a = new SampleClass { Child = new SampleClass { SomeValue = "v" } };
    var result = DataBinder.Eval(a, "Child.SomeValue");
    Console.WriteLine(result); // yields v
