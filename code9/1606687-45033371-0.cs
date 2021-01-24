        public delegate void OnChatNotification(List<SocketUi> sender);
    public class WebSocketClientControl : System.Web.UI.Control, IPostBackDataHandler
    {
        public static ClientService _internalClientService = new ClientService(DServerConfig.ServerAddress.ToString(),
            DServerConfig.ServerSoketPort);
        public event OnChatNotification OnChatNotification = delegate { };
        public WebSocketClientControl()
        {
            _internalClientService.OnChat += _internalClientService_OnChat;
        }
        public void Connect(long userID, SocketEnums.EntityType usertype, string username, string key)
        {
            _internalClientService.Connect(userID, usertype, username, key);
        }
        private void _internalClientService_OnChat(List<SocketUI.SocketUi> sender)
        {
            if (OnChatNotification != null)
                OnChatNotification(sender);
        }
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            String presentValue = postDataKey;
            String postedValue = postCollection[postDataKey];
            if (presentValue == null || !presentValue.Equals(postedValue))
            {
                return true;
            }
            return false;
        }
        public void RaisePostDataChangedEvent()
        {
        }
    }
