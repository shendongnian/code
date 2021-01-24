    private List<Entity> GetAssociatedActivities(EntityReference regarding)
        {
            QueryExpression query = new QueryExpression { EntityName = "activitypointer", ColumnSet = new ColumnSet(new string[] { "activitytypecode" }) };
            query.Criteria.AddCondition("regardingobjectid", ConditionOperator.Equal, regarding.Id);
            query.Criteria.AddCondition("statecode", ConditionOperator.NotEqual, 1);  //ignore completed
            EntityCollection collection = organizationservice.RetrieveMultiple(query);
            foreach (Entity activity in activities.Entities)
            {
              CancelActivity(activity, organizationservice);
            }
        }
       // Cancel an Activity
      private static void CancelActivity(Entity entity, IOrganizationService service)
      {
          EntityReference moniker = new EntityReference();
          if (entity.LogicalName == "activitypointer")
          {
              if (entity.Attributes.Contains("activityid") & entity.Attributes.Contains("activitytypecode"))
              {
                  moniker.LogicalName = entity.Attributes["activitytypecode"].ToString();
                  moniker.Id = (Guid)entity.Attributes["activityid"];
                  SetStateRequest request = new SetStateRequest();
                  request.EntityMoniker = moniker;
                  request.State = new OptionSetValue(2);
                  request.Status = new OptionSetValue(-1);
                  SetStateResponse response = (SetStateResponse)service.Execute(request);
              }
          }
      }
