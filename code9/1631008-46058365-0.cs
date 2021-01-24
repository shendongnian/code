    public class ActionTransactionHelper : IActionTransactionHelper
    {
            private readonly ISessionFactory _sessionFactory;
            private readonly ICurrentSessionContextAdapter _currentSessionContextAdapter;
    
            public ActionTransactionHelper(
                [Named("mssql")] ISessionFactory sessionFactory,
                ICurrentSessionContextAdapter currentSessionContextAdapter)
            {
                _sessionFactory = sessionFactory;
                _currentSessionContextAdapter = currentSessionContextAdapter;
            }
    }
