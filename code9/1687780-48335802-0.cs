    string m_firstname;
        [Required]
        [Display(Name = "First name")]
        [MaxLength(50)]
        [RegularExpression(@"^(?![@=*-])(?!.*[<>]).*$", ErrorMessage = "firstname contains <> or start with @=*-")]
        public string firstname
        {
            get { return m_firstname; }
            set
            {
                Validator.ValidateProperty(value,
                    new ValidationContext(this, null, null) { MemberName = "firstname" });
                m_firstname = value;
            }
        }
