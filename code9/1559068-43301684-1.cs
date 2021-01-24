    private IValidationMessage ValidateEmail(string property)
        {
            const string emailAddressEmptyError = "Email address can not be blank.";
            if (string.IsNullOrEmpty(this.Email))
            {
                var msg = new ValidationErrorMessage(emailAddressEmptyError);
                return msg;
            }
            return new ValidationErrorMessage();
        }
        private IValidationMessage ValidatePassword(string property)
        {
            const string passwordToShortError = "Password must a minimum of 8 characters in length.";
            const string passwordToLongError = "Password must not exceed 16 characters in length.";
            if (this.Password.Length < 8)
            {
                var msg = new ValidationErrorMessage(passwordToShortError);
                return msg;
            }
            if (this.Password.Length > 16)
            {
                var msg = new ValidationErrorMessage(passwordToLongError);
                return msg;
            }
            return new ValidationErrorMessage();
        }
