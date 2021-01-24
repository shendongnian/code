    class ExampleClass
    {
        public string TestProperty {get;set;}
    }
-
    var example = new ExampleClass() { TestProperty = "hello"; }
    bool result = insertDocument(example, e => e.TestProperty);
