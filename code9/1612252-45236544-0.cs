    var defaultMetadata = m as 
        Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata;
    if(defaultMetadata != null)
    {
        var displayAttribute = defaultMetadata.Attributes.Attributes
            .OfType<DisplayAttribute>()
            .FirstOrDefault();
        if(displayAttribute != null)
        {
            return displayAttribute.ShortName;
        }
    }
    return m.DisplayName;
