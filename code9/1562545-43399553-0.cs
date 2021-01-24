    // Note: setting just TagId would be enough
    var contactTag = new ContactTag { Name = marketingContactVM.MarketingContacts[i].Name, TagId = marketingContactVM.MarketingContacts[i].TagId,
    InfusionSoftId = marketingContactVM.MarketingContacts[i].InfusionSoftId};
    contactTags.Add(contactTag);
    // the next line will give you the desired behavior
    context.ContactTags.Attach(contactTag);
