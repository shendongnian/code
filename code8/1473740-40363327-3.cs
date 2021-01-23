    namespace Project2
    {
        public class MyClass2 : Project1.MyClass
        {
            [CustomAttribute]
            public override string prop1 { get; set; }
    
            public string prop2 { get; set; }
        }
    }
