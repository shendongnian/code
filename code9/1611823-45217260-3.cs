     foreach (var condition in filter.ConditionNodes.Where(a => a.IsActive))
     {
          tempBool = false;
          if (!string.IsNullOrWhiteSpace(condition.FieldName) && values.ContainsKey(condition.FieldName))
          {
               var value = values[condition.FieldName];
               if (filter.LogicalOperator == LogicalOperator.Or && ApplyCondition(condition.ConditionOperator, value, condition.FieldValue))
               {
                   tempBool = true;
                   break;
               }
               else if (filter.LogicalOperator == LogicalOperator.And)
               {
                   tempBool = ApplyCondition(condition.ConditionOperator, value, condition.FieldValue);
                   if (!tempBool)
                   {
                        break;
                   }
               }
           }
     }
