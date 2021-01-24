    class FieldValues:Fields
    {
        public Dictionary<int, string> dictionary { get; set; }
    
        public FieldValues(FieldType newType, string newName)
        {
            type = newType;
            name = newName;
            dictionary = new Dictionary<int, string>();
        }
    
        public FieldValues(Fields values)
        {
            type = values.type;
            name = values.name;
            dictionary = new Dictionary<int, string>();
        }
