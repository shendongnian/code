    class Display<Tproperty> : Display
    {
        public override string Value
        {
            get {return this.FetchValue.ToString();}
            set {this.SetValue(Parse(value));}
        }
        public Func<string, TProperty> Parse {get; set;}
        public Func<int, TProperty> FetchValue {get; set;}
        public Action <int, TProperty> SetValue {get; set;}
    }
