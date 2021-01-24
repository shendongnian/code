    public BaseClass
    {
        public BaseClass()
        {
            var MyType = GetType();
            var A = JsonConvert.DeserializeObject("{ json blob }", MyType);
        }
    }
