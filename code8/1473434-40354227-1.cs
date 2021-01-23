    public class MyModel
    {
        [Required]
        [EnumDataType(typeof(EnumType))]
        [DisplayName("Type of Enum")]
        public EnumType? Type { get; set; }
    }
