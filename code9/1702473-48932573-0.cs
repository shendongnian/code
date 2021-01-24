	public class Gender2
    {
        public string LookupType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public List<AlternateCodes> AlternateCodes { get; set; }
    }
    public class AlternateCodes
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string CodeSystem { get; set; }
        public string CodeSystemName { get; set; }
    }
