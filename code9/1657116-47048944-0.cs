    public struct AccessRole
    {
        public AccessRole(Guid guid, int number, string name) : this()
        {
            Uuid = guid;
            Number = number;
            Name = name;
        }
        
        public Guid Uuid {get;}
        public int Number {get;}
        public string Name {get;}
    }
