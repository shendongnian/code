    public class ParamInfo
    {
        public string Name { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsRequired { get; set; }
        public bool IsOptional { get; set; }
        public bool IsForSorting { get; set; }
        public bool IsForPaging { get; set; }
        public Type ExpecteDataType { get; set; }
        public Predicate<string> Validator { get; set; }
    }
