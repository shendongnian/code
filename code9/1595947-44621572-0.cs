        if (property.MetadataProperties.Contains("Configuration"))
        {
            //check if ColumnName has been explicitly configured
            object value = property.MetadataProperties["Configuration"].Value;
            if (value.GetType().GetProperties().Where(p => p.Name == "ColumnName").Any())
            {
                return;
            }
        }
   
