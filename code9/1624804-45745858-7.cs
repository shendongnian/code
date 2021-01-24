    private class TestClass
    {
        public string Arg2 { get; set; }
        public TestClass Nested { get; set; }
    
        public int Id { get; set; }
    }
    var field = new FieldSelector<TestClass>();
    field.Add(e => e.Arg2);
    field.Add(e => e.Id);
    field.Add(e => e.Nested.Id);
    dynamic cusObj = field.GetSelector().Compile()(new TestClass { Arg2 = "asd", Id = 6, Nested = new TestClass { Id = 79 } });
    Console.WriteLine(cusObj.Arg2);
    Console.WriteLine(cusObj.Id);
    Console.WriteLine(cusObj.Nested_Id);
