    var customFilterExpression = new[]
	{
		new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "account"),
		new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, "contact")
	};
	var customFilter = new MetadataFilterExpression(LogicalOperator.Or);
	customFilter.Conditions.AddRange(customFilterExpression);
	var entityProperties = new MetadataPropertiesExpression
	{
		AllProperties = false
	};
	entityProperties.PropertyNames.AddRange("LogicalName", "DisplayName");
	var request = new RetrieveMetadataChangesRequest
	{
		Query = new EntityQueryExpression
		{
			Properties = entityProperties,
			Criteria = customFilter,
		}
	};
