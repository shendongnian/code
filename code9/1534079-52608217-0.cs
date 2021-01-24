    public class LastChangeInterceptor : IDbCommandTreeInterceptor
    {
        public const string LastChangeColumnName = "LastChange";
        public const string LastChangeByColumnName = "LastChangeBy";
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace != DataSpace.SSpace)
            {
                return;
            }
            var lastChange = DateTime.Now;
            var lastChangeBy = HttpContext.Current.User.Identity.Name;
            var insertCommand = interceptionContext.Result as DbInsertCommandTree;
            var updateCommand = interceptionContext.OriginalResult as DbUpdateCommandTree;
            if (insertCommand != null)
            {
                var setClauses = insertCommand.SetClauses
                    .Select(clause => clause.UpdateIfMatch(LastChangeColumnName, DbExpression.FromDateTime(lastChange)))
                    .Select(clause => clause.UpdateIfMatch(LastChangeByColumnName, DbExpression.FromString(lastChangeBy)))
                    .ToList();
                interceptionContext.Result = new DbInsertCommandTree(insertCommand.MetadataWorkspace, insertCommand.DataSpace, insertCommand.Target, setClauses.AsReadOnly(), insertCommand.Returning);
            }
            else if (updateCommand != null)
            {
                var setClauses = updateCommand.SetClauses
                    .Select(clause => clause.UpdateIfMatch(LastChangeColumnName, DbExpression.FromDateTime(lastChange)))
                    .Select(clause => clause.UpdateIfMatch(LastChangeByColumnName, DbExpression.FromString(lastChangeBy)))
                    .ToList();
                interceptionContext.Result = new DbUpdateCommandTree(updateCommand.MetadataWorkspace, updateCommand.DataSpace, updateCommand.Target, updateCommand.Predicate, setClauses.AsReadOnly(), null);
            }
        }
    }
    public static class Extensions
    {
        public static DbModificationClause UpdateIfMatch(this DbModificationClause clause, string property, DbExpression value)
        {
            var propertyExpression = (DbPropertyExpression)((DbSetClause)clause).Property;
            if (propertyExpression.Property.Name == property)
            {
                return DbExpressionBuilder.SetClause(propertyExpression, value);
            }
            return clause;
        }
    }
