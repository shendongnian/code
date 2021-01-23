    public class CustomDbContext : DbContext
    {
        private EntityConnection _entityConnection;
        public CustomDbContext(EntityConnection connection)
            : base(connection, false)
        {
            _entityConnection = connection;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _entityConnection != null)
                _entityConnection.Dispose();
        }
    }
