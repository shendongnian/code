    public class NorthwindCallbackService : INorthwindCallbackService
    {
        /// <summary>
        /// Callbacks to clients.
        /// </summary>
        protected static IDictionary<Guid, INotifierCallback> mCallbacks { get; set; }
        static NorthwindCallbackService()
        {
            NorthwindCallbackService.mCallbacks = new ConcurrentDictionary<Guid, INotifierCallback>();
        }
        public void Subscribe(Guid clientId)
        {
            INotifierCallback callbackForClient;
            callbackForClient = OperationContext.Current.GetCallbackChannel<INotifierCallback>();
            if (NorthwindCallbackService.mCallbacks.ContainsKey(clientId) == false)
            {
                NorthwindCallbackService.mCallbacks.Add(clientId, callbackForClient);
            }
        }
        public void Unsubscribe(Guid clientId)
        {
            INotifierCallback callbackForClient;
            callbackForClient = OperationContext.Current.GetCallbackChannel<INotifierCallback>();
            if (NorthwindCallbackService.mCallbacks.ContainsKey(clientId))
            {
                NorthwindCallbackService.mCallbacks.Remove(clientId);
            }
        }
        public void SendNotification(string notification)
        {
            foreach (var currentCallback in NorthwindCallbackService.mCallbacks)
            {
                try
                {
                    currentCallback.Value.SendNotificationBack(notification);
                }
                catch (ObjectDisposedException)
                {
                    //TODO: When client of NorthwindCallbackService call Dispose() method, we should remove callback of him from NorthwindCallbackService.mCallbacks, but I do not know how to make it.
                }
            }
        }
    }
