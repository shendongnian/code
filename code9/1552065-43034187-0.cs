    public class LoggingModel : PocoBase
    {
        public LoggingModel()
        {
            ValidateForm();
        }
        [Display(Name = "Name")]
        [MaxLength(32), MinLength(4)]
        public string UserName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        [Required]
        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
