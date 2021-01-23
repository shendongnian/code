    string FetchXML =  
        @"<fetch mapping='logical' count='50' version='1.0'>
            <entity name='systemuser'>
                <attribute name='fullname' />
            <link-entity name='systemuserroles' from='systemuserid' to='systemuserid'>
            <link-entity name='role' from='roleid' to='roleid'>
                <attribute name='name' />
            </link-entity>
            </link-entity>
            </entity>
        </fetch>";
    
    EntityCollection result = svcClient.OrganizationServiceProxy.RetrieveMultiple(new Microsoft.Xrm.Sdk.Query.FetchExpression(FetchXML));
    // and then loop thru result
    if (result != null)
    {
    	foreach (var item in result.Entities) {
    		// ... do your stuff here
    		// item.roleName is just an idea.. I haven't tested the code yet..
    		Entity case = new Entity("case");
    
    		if (item.roleName == "role 01") 
    		    	contact.Attributes["customer_field"] = "hard-code value 01";
    		if (item.roleName == "role 02") 
    		    	contact.Attributes["customer_field"] = "hard-code value 02";
    
    		 ...
    		 ...
    	}
    }
 
