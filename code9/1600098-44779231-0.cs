    IEnumerable<Job> GetAll(Expression<Func<StatusEnum, bool>> statusFilter)
    {
        var job = Expression.Parameter(typeof(Job), "job");
        var visitor = new ParameterReplacementVisitor(
            statusFilter.Parameters[0],
            Expression.Property(job, nameof(Job.StatusId)));
        Expression<Func<Job, bool>> jobFilter =
            Expression.Lambda<Func<Job, bool>>(
                visitor.Visit(statusFilter.Body),
                job);
        return jobs.Where(jobFilter);
    }
    
    class ParameterReplacementVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _parameter;
        private readonly Expression _replacement;
        
        public ParameterReplacementVisitor(ParameterExpression parameter, Expression replacement)
        {
            _parameter = parameter;
            _replacement = replacement;
        }
        
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _parameter)
                return _replacement;
            return node;
        }
    }
