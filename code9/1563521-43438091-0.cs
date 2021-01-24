    public virtual void ChangeEmail(string email, EventFactory factory)
    {
        if(this.Email != email)
        {
            this.Email = email;
            UncommitedEvents.Add(factory.createCustomerChangedEmail(email));
        }
    }
