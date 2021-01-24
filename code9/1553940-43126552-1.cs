    public enum AndOr
    {
        And,
        Or
    }
    
    public enum QueryableObjects
    {
        WorkOrderField,
        TaskField
    }
    
    public class ClientCondition
    {
        public AndOr AndOr;
        public QueryableObjects QueryableObject;
        public string PropertyName;
        public string PropertyValue;
    }
    public void PredicateBuilderExample()
    {
        var conditions = new List<ClientCondition> {
        {
            new ClientCondition { AndOr = LINQ.AndOr.And,
                QueryableObject = QueryableObjects.WorkOrderField,
                PropertyName = "System Status",
                PropertyValue = "SETC"
            }
        },
        {
            new ClientCondition{AndOr = AndOr.And,
                QueryableObject = QueryableObjects.TaskField,
                PropertyName = "Material",
                PropertyValue = "Y"
            }
        },
        {
            new ClientCondition{AndOr = AndOr.Or,
                QueryableObject = QueryableObjects.TaskField,
                PropertyName = "Planner",
                PropertyValue = "GR5259"
            }
        }
        };
    
        //Obviously this WorkOrder object is empty so it will always return empty lists when queried.
        //Populate this yourself.
        var WorkOrders = new List<WorkOrder>();
    
        var wofPredicateBuilder = PredicateBuilder.True<WorkOrderField>();
        var tfPredicateBuilder = PredicateBuilder.True<TaskField>();
    
        foreach (var condition in conditions)
        {
            if (condition.AndOr == AndOr.And)
            {
                if (condition.QueryableObject == QueryableObjects.WorkOrderField)
                {
                    wofPredicateBuilder = wofPredicateBuilder.And(
                        wof => wof.Name == condition.PropertyName &&
                            wof.Value.Contains(condition.PropertyValue));
                }
            }
            if (condition.AndOr == AndOr.Or)
            {
                if (condition.QueryableObject == QueryableObjects.TaskField)
                {
                    tfPredicateBuilder = tfPredicateBuilder.Or(
                        tf => tf.Name = condition.PropertyName &&
                            tf.Value.Contains(condition.PropertyValue));
                }
            }
            //And so on for each condition type.
        }
    
        var query = from wo in WorkOrders
                    from woF in wo.Fields.AsQueryable().Where(wofPredicateBuilder)
                    from task in wo.Tasks
                    from taskF in task.Fields.AsQueryable().Where(tfPredicateBuilder)
                    select new
                    {
                        wo_id = wo.ID,
                        task_id = task.ID
                    };
    }
