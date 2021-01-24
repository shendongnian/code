	string GetExplicitlySetColumnName(EdmProperty item)
	{
		// have we a configuration item
		if (item.MetadataProperties.Contains("Configuration"))
		{
			// get the configuration for this item
			var configuration = item.MetadataProperties["Configuration"].Value;
			// get the property info for the ColumnName property if we have one
			var properyInfo = configuration.GetType().GetProperty("ColumnName");
			if (properyInfo != null)
			{
				// if we have a column name property, return the value
				if (properyInfo.GetMethod.Invoke(configuration, null) is String columnName)
				{
					return columnName;
				}
			}
		}
		return null;
	}
