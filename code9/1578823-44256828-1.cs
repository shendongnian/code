    public Microsoft.Xrm.Sdk.Metadata.EntityMetadata[] GetEntities(IOrganizationService organizationService)
        {
            Dictionary<string, string> attributesData = new Dictionary<string, string>();
            RetrieveAllEntitiesRequest metaDataRequest = new RetrieveAllEntitiesRequest();
            RetrieveAllEntitiesResponse metaDataResponse = new RetrieveAllEntitiesResponse();
            metaDataRequest.EntityFilters = EntityFilters.Entity;
    
            XmlDictionaryReaderQuotas myReaderQuotas = new XmlDictionaryReaderQuotas();
            myReaderQuotas.MaxNameTableCharCount = 2147483647;
    
            // Execute the request.
    
            metaDataResponse = (RetrieveAllEntitiesResponse)organizationService.Execute(metaDataRequest);
    
            var entities = metaDataResponse.EntityMetadata;
    
            return entities.OrderBy(x => x.LogicalName).ToArray();//to arrange in ascending order
        }
