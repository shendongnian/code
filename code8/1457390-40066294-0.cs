            public GenericProperty(string name, object value, string match)
        {
            Name = name;
            Value = value;
       **   Match = match; **
        }
        public string Name { get; private set; }
        public object Value { get; set; }
        public string Match { get; set; }
