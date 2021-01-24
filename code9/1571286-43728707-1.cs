    abstract class Node
    {
        /// <summary>
        /// Set of all the ids.
        /// </summary>
        private static ConcurrentDictionary<int, object> _nodes;
        /// <summary>
        /// The Id of the node.
        /// </summary>
        /// <remarks>Can't change.</remarks>
        private readonly int _id;
        /// <summary>
        /// The connections of the node.
        /// </summary>
        private ConcurrentDictionary<int, Node> _connections;
        /// <summary>
        /// Status of the connection for synchronization
        /// </summary>
        private ConcurrentDictionary<int, int> _connectionStatus;
        private const int _connecting = 0;
        private const int _connected = _connecting + 1;
        private const int _disconnecting = _connected + 1;
        protected Node(int id)
        {
            // Try register the Id provided
            if (!_nodes.TryAdd(id, null))
            {
                // If we fail to add it, it means another Node has the same Id already.
                throw new ArgumentException($"The id {id} is already in use", nameof(id));
            }
            // Store the Id for future reference
            _id = id;
        }
        ~Node()
        {
            // Try to release the Id
            // AppDomain unload could be happening
            // Any reference could have been set to null
            // Do not start async operations
            // Do not throw exceptions
            // You may, if you so desire, make Node IDisposable, and dispose including this code
            var nodes = _nodes;
            if (nodes != null)
            {
                nodes.TryRemove(Id, out object waste);
            }
        }
        /// <summary>
        /// The Id of the Node
        /// </summary>
        public int Id { get => _id; }
        /// <summary>
        /// Connects nodes, bidirectionally.
        /// Connect(x, y) is equivalent to Connect(y, x).
        /// </summary>
        /// <param name="x">The first node to connect</param>
        /// <param name="y">The second node to connect</param>
        public static bool Connect(Node x, Node y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            // Bidirectional
            // Take nodes in order of Id, for syncrhonization
            var a = x;
            var b = y;
            if (b.Id < a.Id)
            {
                a = y;
                b = x;
            }
            if (a._connectionStatus.TryAdd(b.Id, _connecting)
                && b._connectionStatus.TryAdd(a.Id, _connecting))
            {
                a._connections[b.Id] = b;
                b._connections[a.Id] = a;
                a._connectionStatus[b.Id] = _connected;
                b._connectionStatus[a.Id] = _connected;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Disconnects nodes, bidirectionally.
        /// Disconnect(x, y) is equivalent to Disconnect(y, x).
        /// </summary>
        /// <param name="x">The first node to connect</param>
        /// <param name="y">The second node to connect</param>
        public static bool Disconnect(Node x, Node y)
        {
            if (x == null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y == null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            // Short circuit
            if (!y._connections.ContainsKey(x.Id) && !x._connections.ContainsKey(y.Id))
            {
                return false;
            }
            // Take nodes in order of Id, for syncrhonization
            var a = x;
            var b = y;
            if (b.Id < a.Id)
            {
                a = y;
                b = x;
            }
            if (a._connectionStatus.TryUpdate(b.Id, _disconnecting, _connected)
                && b._connectionStatus.TryUpdate(a.Id, _disconnecting, _connected))
            {
                a._connections.TryRemove(b.Id, out x);
                b._connections.TryRemove(a.Id, out y);
                int waste;
                a._connectionStatus.TryRemove(b.Id, out waste);
                b._connectionStatus.TryRemove(a.Id, out waste);
                return true;
            }
            return false;
        }
        protected abstract void Recieve(Packet value);
    }
