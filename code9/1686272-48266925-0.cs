    public class PrepareConnectionInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if (!(invocation.InvocationTarget is IDbConnection 
                  && invocation.Method.Name == nameof(IDbConnection.Open)))
            {
                invocation.Proceed();
                return; 
            }
            invocation.Proceed();
            IDbConnection connection = (IDbConnection)invocation.InvocationTarget;
            using(IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SQL statement";
                command.ExecuteNonQuery(); 
            }
        }
    }
