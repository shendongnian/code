    private void fetchDocument(IOrganizationService service, Guid vOrderId) 
    {
        EntityCollection results = null;
        string tempNote = string.Empty;
        string tempFileName = string.Empty;
    
        ColumnSet cols = new ColumnSet("subject", "filename", "documentbody", "mimetype","notetext");
        QueryExpression query = new QueryExpression {
                EntityName = "annotation" ,
                ColumnSet = cols,
                Criteria = new FilterExpression
                {
                    Conditions = {
                    new ConditionExpression("objectid",ConditionOperator.Equal,vOrderId)
                }
                }
                };
        var defaultRecord = service.GetFirstOrDefault(query);
        if(defaultRecord != null)
        {
            if(defaultRecord.Contains("notetext"))
            {
                 tempNote = defaultRecord.GetAttributeValue<string>("notetext");
            }
    
            if (defaultRecord.Contains("filename"))
            {
                tempFileName = defaultRecord.GetAttributeValue<string>("filename");
            } 
        }
    }
