    foreach (var portalItemTag in portalItemTags)
    {
        // Get the tag that matches this portalItemTag.TagId
        var tag = _tags.FirstOrDefault(_ => _.Id == portalItemTag.TagId);
        // If it's not null, copy the tag to this object 
        // and update it's PortalItemTagTypeId property
        if (tag != null)
        {
            // Create a new tag and copy the property values from the other tag to this one
            var newTag = new Tag
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    PortalItemTagTypeId = tag.PortalItemTagTypeId 
                };
            portalItemTag.PortalItemTagTypeId = tag.PortalItemTagTypeId;
            portalItemTag.Tag = newTag;
        }
    }
