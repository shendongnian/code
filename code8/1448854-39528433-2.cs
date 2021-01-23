    ValidatorOptions.DisplayNameResolver = (type, memberInfo, expression) =>
    {
          //this will get in this case, "DocumentNumber", the property name. 
          //If we don't find anything in metadata / resource, that what will be displayed in the error message.
          var displayName = memberInfo.Name;
          //we try to find a corresponding Metadata type
          var metadataType = type.GetCustomAttribute<MetadataTypeAttribute>();
          if (metadataType != null)
          {
               var metadata = metadataType.MetadataClassType;
               //we try to find a corresponding property in the metadata type
               var correspondingProperty = metadata.GetProperty(memberInfo.Name);
               if (correspondingProperty != null)
               {
                    //we try to find a display attribute for the property in the metadata type
                    var displayAttribute = correspondingProperty.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttribute != null)
                    {
                         //finally we got it, try to resolve the name !
                         displayName = displayAttribute.GetName();
                    }
              }
          }
          return displayName ;
    };
