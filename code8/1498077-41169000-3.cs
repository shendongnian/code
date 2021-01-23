    public class MyEntity : IDataErrorInfo
    {
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
                // here you can errors related to the whole object (ex: Password, and PasswordConfirmation do not match)
                return string.Join(Environment.NewLine, Validator.Validate(this)
                                                                    .Select(x => x.ErrorMessage));
            }
        }
        public Boolean IsValid
        {
            get { return string.IsNullOrEmpty(Error); }
        }
    }
