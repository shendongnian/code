    QueryExpression objQueryExpression1 = (QueryExpression)context.InputParameters["Query"];
                    if (objQueryExpression1.EntityName == "email")
                    {
                        objQueryExpression1.Criteria = new FilterExpression(LogicalOperator.And)
                        {
                            Conditions =
                            {
                                new ConditionExpression("new_confidential",ConditionOperator.NotEqual,true)
                            }
                        };
                    }
                    else if (objQueryExpression1.EntityName == "activitypointer")
                    {
                        QueryExpression e = new QueryExpression("email")
                        {
                            Criteria = new FilterExpression(LogicalOperator.And)
                            {
                                Conditions =
                                {
                                    new ConditionExpression("csiro_confidential",ConditionOperator.NotEqual,true)
                                }
                            }
                        };
                        var filteredOutEmails = service.RetrieveMultiple(e).Entities.Select(xc => xc.Id.ToString()).ToArray();
                        objQueryExpression1.Criteria.AddCondition("activityid", ConditionOperator.NotIn,filteredOutEmails);
                    
                    }
                    context.InputParameters["Query"] = objQueryExpression1;  
