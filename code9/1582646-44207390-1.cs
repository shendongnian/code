    class ConnectionManager {
        private readonly BasicConcurrentSet<Connection> _connections = new BasicConcurrentSet<Connection>();
        internal ConnectionManager() {
        }
        internal void AddConnection(Connection connection) {
            _connections.Add(connection);
            OnAddConnection(Connection);
        }
        internal void RemoveConnection(Connection connection) {
            _connections.Remove(connection);
            OnRemoveConnection(connection);
        }
        internal void DisconnectConnections() {
            foreach (var connection in _connections) {
                connection.Disconnect();
            }
        }
    }
