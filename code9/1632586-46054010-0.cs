    using (ClientContext context = new ClientContext(webFullUrl: siteUrl))
    {
    	context.Credentials = new SharePointOnlineCredentials(userName, GetPassWord());
    
    	Web web = context.Web;
    	
    	List booksList = context.Web.Lists.GetByTitle("Books");
    
    	List list = context.Web.Lists.GetByTitle("BillTokenStore");
    	FieldCollection fields = list.Fields;
    
    	context.Load(list);
    	context.Load(booksList, b => b.Id);
    	context.Load(fields);
    
    	context.ExecuteQuery();
    
    	string schemaLookupField = @"<Field Type='Lookup' Name='InStock' StaticName='InStock' DisplayName='InStock' List='{"+ booksList.Id +"}' ShowField = 'Title' />";
    	Field lookupField = fields.AddFieldAsXml(schemaLookupField, true, AddFieldOptions.DefaultValue);
    	lookupField.Update();
    
    	context.Load(lookupField);
    	context.ExecuteQuery();     
    }
