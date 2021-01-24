    public class SimpleClass
    {
        private readonly StringBuilder _builder = new StringBuilder();
    
        public SimpleClass Method1()
        {
            _builder.Append("Method1");
            return this;
        }
    
        public SimpleClass Method2()
        {
            _builder.Append("Method2");
            return this;
        }
    
        public string GetProp()
        {
            return _builder.ToString();
        }
    }
