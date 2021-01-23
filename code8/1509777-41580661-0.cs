    public class ParameterVM
    {
        public string Name { get; set; }
        public bool HasRange { get; set; }
        [RequiredIfFalse(ErrorMessage = "...")]
        public int? Value { get; set; }
        [RequiredIfTrue("HasRange", ErrorMessage = "...")]
        public int? LowerLimit { get; set; }
        [RequiredIfTrue("HasRange", ErrorMessage = "...")]
        public int? UpperLimit { get; set; }
    }
