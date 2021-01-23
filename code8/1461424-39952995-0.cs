    public class CRMNextField
    {
        public string FieldName { get; set; }
        public string CastRequired { get; set; }
        public string DefaultValue { get; set; }
        public string Description { get; set; }
        public string FieldID { get; set; }
        public string KeyID { get; set; }
        public string Label { get; set; }
        public string IsMandatory { get; set; }
        public string MaxValue { get; set; }
        public string MinValue { get; set; }
        public string Type { get; set; }
        public string IsLookup { get; set; }
        public string LinkedFields { get; set; }
        public string FieldKey { get; set; }
        public string TextFieldName { get; set; }
        public string ErrorMessage { get; set; }
        public string LayoutFieldId { get; set; }
        public string LayoutType { get; set; }
        public string IsDNC { get; set; }
        public string DNCField { get; set; }
        public string ReturnType { get; set; }
    }
    
    public class RootObject
    {
        public List<CRMNextField> CRMNextFields { get; set; }
    }
