        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includePaths)
            {
    DbSet = Context.Set<TEntity>();
        var query = includePaths.Aggregate(DbSet, (current, item) => EvaluateInclude(current, item));
                 return query.Where(predicate).FirstOrDefault();
            }
            
        private IQueryable<T> EvaluateInclude(IQueryable<T> current, Expression<Func<T, object>> item)
                    {
                        if (item.Body is MethodCallExpression)
                        {
                            var arguments = ((MethodCallExpression)item.Body).Arguments;
                            if (arguments.Count > 1)
                            {
                                var navigationPath = string.Empty;
                                for (var i = 0; i < arguments.Count; i++)
                                {
                                    var arg = arguments[i];
                                    var path = arg.ToString().Substring(arg.ToString().IndexOf('.') + 1);
            
                                    navigationPath += (i > 0 ? "." : string.Empty) + path;
                                }
                                return current.Include(navigationPath);
                            }
                        }
            
                        return current.Include(item);
                    }
