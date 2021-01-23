    [Required]
    [AssertThat("IsEmail(EmailOrPhone) || (Length(EmailOrPhone) > 8 && Length(EmailOrPhone) < 16 && IsRegexMatch(EmailOrPhone, '^\\d+$'))",
        ErrorMessageResourceType = typeof (Resources), ErrorMessageResourceName = nameof(Resources.EmailFormatInvalid))]
    [Display(Name = "EmailOrPhone")]
    public string EmailOrPhone { get; set; }
