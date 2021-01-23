    public void IdentifyType(EntityReference reference)
    {
        switch(reference.LogicalName)
        {
            case Account.EntityLogicalName:
                //Do something if it's an account.
                Console.WriteLine($"The entity is of type {nameof(Account.EntityLogicalName)}."
            case Contact.EntityLogicalName:
                //Do something if it's a contact.
                Console.WriteLine($"The entity is of type {nameof(Contact.EntityLogicalName)}."
            default:
                //Do something if neither of above returns true.
                Console.WriteLine($"The entity is not of type {nameof(Account.EntityLogicalName)} or {nameof(Contact.EntityLogicalName)}."
        }
    }
