    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
        if (this.CCommmunication == Commmunication.TelephoneNo && string.IsNullOrEmpty(this.MobileTelephoneNo))
        {
        yield return new ValidationResult("Please enter telephone number", new[] { "MobileTelephoneNo" }); //returns message
        }
        // Confirm ConfirmMobileTelephoneNo matches.
        if (this.CCommmunication == Commmunication.TelephoneNo && ConfirmMobileTelephoneNo != MobileTelephoneNo)
        {
        yield return new ValidationResult("Please ensure confirm mobile number matches", new[] { "ConfirmMobileTelephoneNo" }); //returns message
        }
