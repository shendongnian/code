    public abstract class BaseSupplier
    {
        protected BaseSupplier(FtpCredentials credentials)
        {
            _Credentials = credentials;
        }
        private FtpCredentials _Credentials;
        public void Run()
        {
            Connect();
            Process();
            Disconnect();
        }
        private void Connect() {/* your connection and login code */}
        private void Disconnect() {/* your disconnect code */}
        protected abstract void Process(); // to be filled in the derived class
    }
    public class ConcreteSupplier
    {
        public ConcreteSupplier(FtpCredentials credentials, SomeType parameter) : base(credentials)
        { /* store extra parameters */ }
        override Process() {/*your concrete processing code */ }
    }
