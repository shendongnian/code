    [Serializable]
    [XmlType(TypeName = "FH")]
    public class FH
    {
        public string G_ID{ get; set; }
        public string G_CK{ get; set; }
        public string CS_ID{ get; set; }
        public string C_ID{ get; set; }
        public bool AllowD{ get; set; }
        public string S_ID{ get; set; }
        public string S_CK{ get; set; }
        public FT FT { get; set; }
        public bool IsR{ get; set; }
    }
    [Serializable]
    public class FT
    {
        public string ID{ get; set; }
        public string Name{ get; set; }
        public string Purp{ get; set; }
    }
