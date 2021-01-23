    public interface IProcessor
    {
        void Process(Credentials credentials);
    }
    public class Credentials
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public abstract class SupplierBase : IProcessor, IDisposable
    {
        protected FtpConnection _Connection;
        private void Connect(Credentials credentials)
        {
            //Create the ftp connection
            _Connection = new FtpConnection(credentials.Host, credentials.Username, credentials.Password);
            _Connection.Open();
            _Connection.Login();
        }
        private void Disconnect()
        {
            //Close and dispose the ftp connection
            _Connection.Close();
            _Connection.Dispose();
            _Connection = null;
        }
        public void Process(Credentials credentials)
        {
            Connect(credentials);
            Execute();
            Disconnect();
        }
        protected abstract void Execute();
        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_Connection != null)
                {
                    _Connection.Dispose();
                    _Connection = null;
                }
            }
        }
        #endregion
    }
    public void MySupplier : SupplierBase
    {
        //You can add unique supplier properties here.
        public string SomeProperty { get; set; }
        protected override void Execute()
        {
            //Implementation here
            Console.WriteLine(SomeProperty);
        }
    }
