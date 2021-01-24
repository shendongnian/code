    abstract class Node
    {
        /// <summary>
        /// Set of all the ids.
        /// </summary>
        private static Dictionary<int, object> _nodes;
        /// <summary>
        /// The Id of the node.
        /// </summary>
        /// <remarks>Can't change.</remarks>
        private readonly int _id;
        /// <summary>
        /// The connections of the node.
        /// </summary>
        private Dictionary<int, Node> _connections;
        protected Node(int id)
        {
            // Try register the Id provided
            if (_nodes.ContainsKey(id))
            {
                // If we fail to add it, it means another Node has the same Id already.
                throw new ArgumentException($"The id {id} is already in use", nameof(id));
            }
            _nodes.Add(id, null);
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
                nodes.Remove(Id);
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
        public static void Connect(Node x, Node y)
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
            x._connections[y.Id] = y;
            y._connections[x.Id] = x;
        }
        /// <summary>
        /// Disconnects nodes, bidirectionally.
        /// Disconnect(x, y) is equivalent to Disconnect(y, x).
        /// </summary>
        /// <param name="x">The first node to connect</param>
        /// <param name="y">The second node to connect</param>
        public static void Disconnect(Node x, Node y)
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
            if (y._connections.ContainsKey(x.Id) && x._connections.ContainsKey(y.Id))
            {
                // Bidirectional
                x._connections.Remove(y.Id);
                y._connections.Remove(x.Id);
            }
        }
        protected abstract void Recieve(Packet value);
    }
