    public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService =
               (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));
            IOrganizationServiceFactory serviceFactory =
                (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            IOrganizationService organizationService = serviceFactory.CreateOrganizationService(context.UserId);
            Entity TargetEntity = new Entity();
             
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                TargetEntity = (Entity)context.InputParameters["Target"];
                
                QueryExpression queryDuplicateDetect = new QueryExpression(TargetEntity.LogicalName);
                if (TargetEntity.LogicalName == "account" && TargetEntity.Attributes.Contains("name"))
                {
                    queryDuplicateDetect.ColumnSet = new ColumnSet(new string[] { "name" });
                    queryDuplicateDetect.Criteria.AddCondition(new ConditionExpression("name", ConditionOperator.Equal, TargetEntity["name"].ToString()));
                }
                else if (TargetEntity.LogicalName == "contact" && TargetEntity.Attributes.Contains("fullname"))
                {
                    queryDuplicateDetect.ColumnSet = new ColumnSet(new string[] { "fullname" });
                    queryDuplicateDetect.Criteria.AddCondition(new ConditionExpression("fullname", ConditionOperator.Equal, TargetEntity["fullname"].ToString()));
                }
                try
                {
                    EntityCollection resultsColl = organizationService.RetrieveMultiple(queryDuplicateDetect);
                    if (resultsColl.Entities.Count > 0)
                    {
                        foreach (Entity e in resultsColl.Entities)
                        {
                            tracingService.Trace("Record Found with ID {0}", e.Id);
                        }
                        //log results in some entity for more info 
                        throw new InvalidPluginExecutionException("Duplicate detected.");
                    }
                }
                catch (Exception e)
                {
                    throw new InvalidPluginExecutionException(e.Message);
                }
            }
        }
