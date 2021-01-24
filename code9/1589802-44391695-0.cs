    // Get your cc field
    var cc = email.GetAttributeValue<EntityCollection>("cc");
    // Iterate through the collection. If there's a partyId, it's a party list, so remove it
    cc.Entities.ToList().ForEach(entity =>
    {
        var partyId = entity.GetAttributeValue<EntityReference>("partyid");
        if (partyId != null)
            cc.Entities.Remove(entity);
    }
    // Update your email
    email["cc"] = cc;
    service.Update(email);
