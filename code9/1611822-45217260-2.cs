     foreach (var condition in filter.ConditionNodes.Where(a => a.IsActive))
     {
          tempBool = false;
          if (!string.IsNullOrWhiteSpace(condition.FieldName) && values.ContainsKey(condition.FieldName))
          {
               var value = values[condition.FieldName];
               tempBool == ApplyCondition(condition.ConditionOperator, value, condition.FieldValue);
               
               if ((filter.LogicalOperator == LogicalOperator.And && !tempBool) || filter.LogicalOperator == LogicalOperator.Or)
               {
                    break;
               }
           }
     }
