        internal class TemporalTableCommandTreeInterceptor : IDbCommandTreeInterceptor
        {
            private static ReadOnlyCollection<DbModificationClause> GenerateSetClauses(IList<DbModificationClause> modificationClauses)
            {
                var props = new List<DbModificationClause>(modificationClauses);
                props = props.Where(_ => !_ignoredColumns.Contains((((_ as DbSetClause)?.Property as DbPropertyExpression)?.Property as EdmProperty)?.Name)).ToList();
    
                var newSetClauses = new ReadOnlyCollection<DbModificationClause>(props);
                return newSetClauses;
            }
        }
