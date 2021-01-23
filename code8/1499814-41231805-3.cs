    // Interface:
    public interface ILogger : IDisposable
    {
         void Log<TEntity>(TEntity entity);
    }
    
    // Concrete Implementation:
    public class DatabaseLogger : ILogger
    {
         public void Log<TEntity>(TEntity entity)
         {
              throw new NotImplementedException();
         }
    }
    
    public class TextLogger : ILogger
    {
         public void Log<TEntity>(TEntity entity)
         {
              throw new NotImplementedException();
         }
    }
