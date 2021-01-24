	using Microsoft.Xrm.Sdk;
	using Microsoft.Xrm.Sdk.Query;
	using Microsoft.Xrm.Tooling.Connector;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	public void Run()
	{
		var list = OppProducts(svc, new Guid("628CF01A-AED1-E411-80EF-C4346BAC7BE8"));
		DeleteList(svc, list);
	}
	public List<Entity> OppProducts(IOrganizationService svc, Guid OppId)
	{
		var query = new QueryExpression
		{
			EntityName = "opportunityproduct",
			ColumnSet = new ColumnSet("opportunityid", "opportunityproductid"),
			Criteria = new FilterExpression
			{
				FilterOperator = LogicalOperator.And,
				Conditions =
				{
					new ConditionExpression
					{
						AttributeName = "opportunityid",
						Operator = ConditionOperator.Equal,
						Values = { OppId }
					}   
				}
			}
		};
		var result = svc.RetrieveMultiple(query);
		return result.Entities.ToList();
	}
	public void DeleteList(IOrganizationService svc, List<Entity> list)
	{
		list.ForEach(e => svc.Delete(e.LogicalName, e.Id));
	}
