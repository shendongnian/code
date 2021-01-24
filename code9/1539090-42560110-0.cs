    public void CreateCustomerLookUp(CustomerLookUp customerLookUp)
    {
    	using (var context = new CustomerContext())
    	{
    		customerLookUp.LastUpdated = DateTime.Now;
    
    		var encryptedCustomerLookUp = EncryptCustomerLookUp(customerLookUp);
    
    		var newCustomerLookup = new CustomerLookUp()
    		{
    			AccountNumber = encryptedCustomerLookUp.AccountNumber,
    			EmailAddress = encryptedCustomerLookUp.EmailAddress,
    			MobileNumber = encryptedCustomerLookUp.MobileNumber,
    			UmbracoMemberId = encryptedCustomerLookUp.UmbracoMemberId,
    			UpdateCode = encryptedCustomerLookUp.UpdateCode,
    			UpdateNotification = encryptedCustomerLookUp.UpdateNotification
    		};
    
			context.Entry(customerLookUp).State = EntityState.Modified;
			context.CustomerLookUps.Add(newCustomerLookup);
			context.SaveChanges();
    	}
    }
