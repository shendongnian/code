    Entity accountEntity = new Entity("new_categoryoption");
    accountEntity["new_categorylist"] = new OptionSet( GetOptionsSetValueOnText(service, "new_categoryoption", "new_categorylist", dt.Rows[i][1].ToString()));
            
            
    public int GetOptionsSetValueOnText(IOrganizationService service, string entitySchemaName, string attributeSchemaName, string optionsetText)
    {
        RetrieveAttributeRequest retrieveAttributeRequest = new RetrieveAttributeRequest
        {
            EntityLogicalName = entitySchemaName,
            LogicalName = attributeSchemaName,
            RetrieveAsIfPublished = true
        };
        RetrieveAttributeResponse retrieveAttributeResponse = (RetrieveAttributeResponse)service.Execute(retrieveAttributeRequest);
        PicklistAttributeMetadata retrievedPicklistAttributeMetadata = (PicklistAttributeMetadata)retrieveAttributeResponse.AttributeMetadata;
        OptionMetadata[] optionList = retrievedPicklistAttributeMetadata.OptionSet.Options.ToArray();
        
        int optionsetValue = 0;
        if (optionList.Length > 0)
        {
            optionsetValue = (from a in optionList
                        where a.Label.UserLocalizedLabel.Label == optionsetText
                        select a.Value).First();
        }
        return optionsetValue ;
    }
