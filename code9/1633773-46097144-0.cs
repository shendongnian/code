    public class Lookup
    {
        [Required]
        public string ValueName { get; set; }
        public string ValueNameDataColumnName => nameof(ValueName);
    }
