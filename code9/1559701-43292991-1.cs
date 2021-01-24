    public struct NullableStruct
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public NullableClass()
        {
            ID = new Guid();
            Name = "";
        }
        public NullableClass(string Name)
        {
            this.Name = Name;
        }
    }
