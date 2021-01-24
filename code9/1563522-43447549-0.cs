    public CustomerChangedEmail ChangeEmail(string email)
    {
        if(this.Email.Equals(email))
        {
            throw new DomainException("Cannot change e-mail since it is the same.");
        }
        return On(new CustomerChangedEmail { EMail = email});
    }
    public CustomerChangedEmail On(CustomerChangedEmail customerChangedEmail)
    {
        // guard against a null instance
        this.EMail = customerChangedEmail.EMail;
        return customerChangedEmail;
    }
