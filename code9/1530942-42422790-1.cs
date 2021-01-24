    public class NotificationListener : INotificationListener
    {
        public void OnMessage(JObject values)
        {
            // TOOD: - Handle incoming notifications
        }
    
        public async void OnRegister(string deviceToken)
        {
            // TODO: - Register the devices token in the server
        }
    }
    public class NotificationManager
    {
        
        private static NotificationManager _current = null;
    
        /// <summary>
        /// Shared instance of the Notification Manager
        /// </summary>
        public static NotificationManager Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new NotificationManager();
                }
                return _current;
            }
        }
        
        /// <summary>
        /// The member responsible for handling notifications
        /// </summary>
        public static INotificationListener Listener { get; private set; }
    
        /// <summary>
        /// Initializes the Notification Manager with an instance of the specified handler in type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void Initialize<T>() where T: INotificationListener, new()
        {
            Listener = new T();
        }
        
    }
