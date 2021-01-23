    using Microsoft.Xrm.Sdk;
	using Microsoft.Xrm.Sdk.Query;
	using Microsoft.Xrm.Tooling.Connector;
	using System.Linq;
	private string getFetchXml(IOrganizationService svc)
	{
		var query = new QueryExpression
		{
			EntityName = "userquery",
			ColumnSet = new ColumnSet("userqueryid", "name", "fetchxml"),
			Criteria = new FilterExpression
			{
				FilterOperator = LogicalOperator.And,
				Conditions =
				{
					new ConditionExpression
					{
						AttributeName = "name",
						Operator = ConditionOperator.Equal,
						Values = {"My View"}
					},
					new ConditionExpression
					{
						AttributeName = "returnedtypecode",
						Operator = ConditionOperator.Equal,
						Values = { "account" }
					}
				}
			}
		};
		var result = svc.RetrieveMultiple(query);
		var view = result.Entities.FirstOrDefault();
		var fetchXml = view.GetAttributeValue<string>("fetchxml");
		return fetchXml;
	}
