    using System.Data;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    namespace DataAccess.Infrastructure
    {
     public class ConnectionFactory : IConnectionFactory
     {
        public ConnectionFactory()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
        public IConfigurationRoot Configuration { get; }
        public IDbConnection GetConnection
        {
            get
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                var conn = new SqlConnection(connectionString);
                conn.Open();
                return conn;
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }
        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    } }
