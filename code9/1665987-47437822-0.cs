    [XmlType(TypeName = "Profile")]
    public class ProfileSearch {
        public int ProfileId { get; set; }
        public string Company { get; set; }
        public List<Field> AdditionalData { get; set; }
    }
    
    public class Field {
        public string FieldName { get; set; }
        public object Value { get; set; }
        //More Properties Like DataType...
    }
