       public class LoggingQueryProvider : EntityQueryProvider
        {
            public LoggingQueryProvider(IQueryCompiler queryCompiler) : base(queryCompiler) { }
    
            public override object Execute(Expression expression)
            {
                var result = base.Execute(expression);
                //log
                return result;
            }
            public override TResult Execute<TResult>(Expression expression)
            {
                var result = base.Execute<TResult>(expression);
                //log
                return result;
            }
            public override IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
            {
                var result = base.ExecuteAsync<TResult>(expression);
                //log
                return result;
            }
            public override Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
            {
                var result = base.ExecuteAsync<TResult>(expression, cancellationToken);
                //log
                return result;
            }
        }
