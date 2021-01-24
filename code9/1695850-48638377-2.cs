     public static CustomItem FirstCustom(this IEnumerable<CustomItem> source, Expression<Func<CustomItem, bool>> predicate)
        {
            BinaryExpression binExpr = null;
            Expression value = null;
            try
            {
                binExpr = predicate.Body as BinaryExpression;
                value = binExpr.Right;
                var func = predicate.Compile();
                return source.First(func);
            }
            catch (Exception e)
            {
                throw new Exception($" No result found for {value} {e.Message}");
            }
        }
