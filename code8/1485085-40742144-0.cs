    public class TemporalTableCommandTreeInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                var insertCommand = interceptionContext.Result as DbInsertCommandTree;
                if (insertCommand != null)
                {
                    var namesToIgnore = new List<string> { "ValidFrom", "ValidTo" };
                    var props = new List<DbModificationClause>(insertCommand.SetClauses);
                    props = props.Where(_ => !namesToIgnore.Contains((((_ as DbSetClause)?.Property as DbPropertyExpression)?.Property as EdmProperty)?.Name)).ToList();
                    var newSetClauses = new ReadOnlyCollection<DbModificationClause>(props);
                    var newCommand = new DbInsertCommandTree(
                        insertCommand.MetadataWorkspace,
                        insertCommand.DataSpace,
                        insertCommand.Target,
                        newSetClauses,
                        insertCommand.Returning);
                    interceptionContext.Result = newCommand;
                };
            }
        }
