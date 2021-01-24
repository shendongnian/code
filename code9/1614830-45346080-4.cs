        public Method(string name)
        {
            Name = name;
        }
    And `Name` should be read only:
        public string Name { get; }
