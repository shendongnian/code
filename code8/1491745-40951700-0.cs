    public partial class ContextDB : DbContext
    {
        // New constructor
        public ContextDB(DbConnection connection)
            : base(connection, false)
        {
        }
    }
    public class TransactionPerRequest :
        IRunOnEachRequest, IRunOnError, IRunAfterEachRequest
    {
        private readonly ContextDB _Context;
        private readonly HttpContextBase _HttpContext;
        private readonly DbConnection _cnn;
        public TransactionPerRequest(HttpContextBase httpContext)
        {
            // Your code creates the connection
            _cnn = new SqlConnection("Data Source=.;Initial Catalog=DB;Integrated Security=SSPI;");
            // Pass connection your context
            _Context = new ContextDB(_cnn);
            _HttpContext = httpContext;
        }
    
        void IRunOnEachRequest.Execute()
        {
            // Open connection
            _cnn.Open();
            _HttpContext.Items["_Transaction"] =
                _cnn.BeginTransaction(IsolationLevel.ReadCommitted);
        }
    
        void IRunOnError.Execute()
        {
            _HttpContext.Items["_Error"] = true;
        }
    
        void IRunAfterEachRequest.Execute()
        {
            var transaction = (DbContextTransaction)_HttpContext.Items["_Transaction"];
    
            if (_HttpContext.Items["_Error"] != null)
                transaction.Rollback();
            else
                transaction.Commit();
            _cnn.Close();
            _cnn.Dispose();
        }
    }
