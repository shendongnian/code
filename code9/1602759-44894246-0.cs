    protected void CreateTenantDbContext()
    {
    	if (tenantContext == null)
    	{
    		using (var context = LocalIocManager.Resolve<MyAppDbContext>())
    		{
    			// AbpSession.TenantId is set in a previous method.
    			// Usin the host context, get the Connection String for the necessary tenant
    			var encryptedDbConnString = context.Tenants.FirstOrDefault(x => x.Id == AbpSession.TenantId)?.ConnectionString;
    			
    			// Decrypt the string
    			var decryptedDbConnString = SimpleStringCipher.Instance.Decrypt(encryptedDbConnString);
    
    			// Create the context for the tenant db and assign it to the static property tenantContext
    			tenantContext = LocalIocManager.Resolve<MyAppDbContext>(new { nameOrConnectionString = decryptedDbConnString });
    		}
    	}
    }
