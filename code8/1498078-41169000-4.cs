    public class MyEntity : IDataErrorInfo
    {
        [Required]
        public string Name { get; set; }
        public string this[string columnName]
        {
            get
            {
                // here you can validate each property of your class (POCO object)
                var result = string.Join(Environment.NewLine, Validator.Validate(this, columnName).Select(x => x.ErrorMessage));
                return result;
            }
        }
        public string Error
        {
            get
            {
                // here you can validate errors related to the whole object (ex: Password, and PasswordConfirmation do not match)
                return string.Join(Environment.NewLine, Validator.Validate(this)
                                                                    .Select(x => x.ErrorMessage)
                                                                    .Union(ModelError.Select(m => m.Value)));
            }
        }
        public Boolean IsValid
        {
            get { return string.IsNullOrEmpty(Error); }
        }
    }
