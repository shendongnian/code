     interface IPluginInterface { }
    
        class Foo:IPluginInterface
        {
            public int SomeInt { get; set; }
            public string SomeString { get; set; }
    
            public Foo()
            {
                SomeInt = 42;
                SomeString = "SomeString";
            }
    
            public override string ToString() => $"SomeInt: {SomeInt}. SomeString: {SomeString}";
        }
