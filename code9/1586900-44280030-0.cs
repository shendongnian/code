    namespace System.Data.Entity.Infrastructure.Interception
    {
      public interface IDbCommandInterceptor : IDbInterceptor
      {
        void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext);
    
        void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext);
    
        void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext);
    
        void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext);
    
        void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext);
    
        void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext);
      }
    }
