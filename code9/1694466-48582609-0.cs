    class MyGenericClass<T>
    {
        public MyGenericClass(Func<string, T> parseFunc)
        {
             this.parseFunc = parseFunc;
        }
        private readonly Func<string, T> parseFunc;
        public void Add(string txt) 
        {
            this.Add(parseFunc(txt));
        }
    }
