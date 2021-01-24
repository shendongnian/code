    [MyInitializer(Value = "Test")]
    class Test
    {
        public Test()
        {
            this.Value = this.GetType().GetAttributes().OfType<MyInitializerAttribute>().Value;
        }
        public string Value { get; set; }
    }
           
 
