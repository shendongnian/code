    public class SocketHandler
    {
        private Socket _serverSocket; // not read-only
        /* ... */
        public void Dispose()
        {
            Socket tmp = _serverSocket; // save instance
            _serverSocket = null; // set field to null
            tmp?.Close();
        }
