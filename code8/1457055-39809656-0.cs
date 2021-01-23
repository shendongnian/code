    public EmailOrPhone : ValidationAttribute
    {
        public override IsValid(object value)
        {
            var emailOrPhone = value as string;
            // Is this a valid email address?
            if (this.IsValidEmailAddress(emailOrPhone))
            {
               // Is valid email address
               return true;
            }
            else if (this.IsValidPhoneNumber(emailOrPhone))
            {
                // Assume phone number
                return true;
            }
            // Not valid email address or phone
            return false;
        }
        private bool IsValidEmailAddress(string emailToValidate)
        {
            // Get instance of MVC email validation attribute
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(emailOrPhone);
        }
        private bool IsValidPhoneNumber(string phoneNumberToValidate)
        {
            // Regualr expression from http://stackoverflow.com/a/8909045/894792 for phone numbers
            var regex = new Regex("^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            return refex.IsMatch(phoneNumberToValidate)
        }
    }
