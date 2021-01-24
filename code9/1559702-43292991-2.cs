    public struct NullableStruct
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public NullableStruct(string Name)
        {
            this.Name = Name;
        }
    }
