        public string Name { get; private set; }
        public PhoneGroup(string name)
            : base()
        {
            Name = name;
        }
        public PhoneGroup(string name, IEnumerable<Phone> source)
            : base(source)
        {
            Name = name;
        }
    }
