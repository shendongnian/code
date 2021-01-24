    foreach (PropertyInfo propertyInfo in md.GetType().GetProperties())
    {
       new FormMetaData
       {
         FormFieldName = propertyInfo.Name,
         MetadataLabel = propertyInfo.GetValue(md) // <--
       }
    }
