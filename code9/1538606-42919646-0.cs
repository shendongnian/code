    public class PreContactRetrieveMultiple : CrmPlugin
    {
        protected override void Execute(PluginVars variables)
        {
            if (variables.Context.InputParameters.Contains("Query") && variables.Context.InputParameters["Query"] is QueryExpression)
            {
                QueryExpression objQueryExpression = (QueryExpression) variables.Context.InputParameters["Query"];
                var processQuery = query.LinkEntities.FirstOrDefault(le => le.LinkFromAttributeName == "processid");
                if (processQuery != null)
                {
                    query.LinkEntities.Remove(processQuery);
                }
                query.ColumnSet = new ColumnSet(query.ColumnSet.Columns.Distinct().ToArray());
                query.ColumnSet.Columns.Remove("processid");
                query.ColumnSet.Columns.Remove("processts");
                query.PageInfo.Count = 5000;
            }
        }
    }
