    public override EntityCollection RetrieveMultiple(QueryBase query)
    {
       RetrieveMultipleRequest retrieveMultipleRequest = new      RetrieveMultipleRequest();
       retrieveMultipleRequest.Query = query;
       RetrieveMultipleResponse multipleResponse = this.Execute<RetrieveMultipleResponse>((OrganizationRequest) retrieveMultipleRequest);
       if (multipleResponse == null)
         return (EntityCollection) null;
       else
         return multipleResponse.EntityCollection;
    }
    public EntityCollection EntityCollection
    {
       get
       {
         if (this.Results.Contains("EntityCollection"))
            return (EntityCollection) this.Results["EntityCollection"];
         else
            return (EntityCollection) null;
       }
    }
