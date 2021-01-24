    class Foobar
    {
        public string bla { get; set; }
        public Foobar()
        {
            this.bla = "hello world";
        }
        public string this[string name]
        {
            get
            {
                return this.GetType().GetProperty(name).GetValue(this, null).ToString();
            }
        }
    }
