    [DisplayName("Not Recommended")]
    public bool NotRecommended { get; set; }
    [DataType(DataType.MultilineText)]
    [MaxLength(1500)]
    [DisplayName("Notes")]
    [RequiredWhen("NotRecommended", true, AllowEmptyStrings = false, ErrorMessage ="A note is required when flagging an Assessor.")]
    public string Notes { get; set; }
