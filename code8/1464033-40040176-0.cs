            var pluginContext = localContext.PluginExecutionContext;
            if (!pluginContext.InputParameters.Contains("Target") ||
                !(pluginContext.InputParameters["Target"] is Entity)) return;
            var target = pluginContext["Target"] as Entity;
            var annotationQuery = new QueryExpression
            {
                EntityName = "annotation",
                ColumnSet = new ColumnSet(true),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("objectid", ConditionOperator.Equal, target.Id)
                    }
                }
            };
            var response = localContext.OrganizationService.RetrieveMultiple(annotationQuery);
            if (!response.Entities.Any()) 
                throw new InvalidPluginExecutionException("No Notes were found for the entity");
             //Further checks against content...
