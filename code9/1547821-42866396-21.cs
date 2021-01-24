    class ToolModel
    {
        public long Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Coating { get; set; }
        public bool Thread { get; set; }
        public string Kind { get; set; }
        //  Like so
        public long ToolTypeId { get; set; }
        public ToolTypeModel Type { get; set; }
    }
