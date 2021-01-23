    using (DatabaseContext dbContext = new DatabaseContext())
    {
        ObjectParameter isDuplicate = new ObjectParameter("isDuplicate", typeof(bool)); 
        var result = dbContext.EmailAddressIsDuplicate(emailAddress, isDuplicate);
        
        bool emailIsDuplicate = (bool)isDuplicate.Value;.    
    }
