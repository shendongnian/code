    //Initilizing ContentKeyAuthorizationPolicyRestriction
      ContentKeyAuthorizationPolicyRestriction restriction = new ContentKeyAuthorizationPolicyRestriction
      {
          Name = "Authorization Policy with Token Restriction",
          KeyRestrictionType = (int)ContentKeyRestrictionType.TokenRestricted,
          Requirements = TokenRestrictionTemplateSerializer.Serialize(restrictionTemplate)};
    
      restrictions.Add(restriction);
    
      //Saving IContentKeyAuthorizationPolicyOption on server so it can be associated with IContentKeyAuthorizationPolicy
      IContentKeyAuthorizationPolicyOption policyOption = objCloudMediaContext.ContentKeyAuthorizationPolicyOptions.Create("myDynamicEncryptionPolicy", ContentKeyDeliveryType.BaselineHttp, restrictions, String.Empty);
      policy.Options.Add(policyOption);
    
      //Saving Policy
      policy.UpdateAsync();
