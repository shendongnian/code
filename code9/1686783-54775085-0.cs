    // Setup as /notification-hub
    public class NotificationHub : Hub {
        public string ConnectionId() => Context.ConnectionId;
        public static event Action<string, string> Response;
        public void Callback(string connectionId, string message) {
            Response?.Invoke(connectionId, message);
        }
    }
Service:
    // Wire it up using DI
    public class NotificationService {
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        public NotificationService(IHubContext<NotificationHub> notificationHubContext) {
            _notificationHubContext = notificationHubContext;
        }
        public async Task<string> ConfirmAsync(string connectionId, string text, IEnumerable<string> choices) {
            await _notificationHubContext.Clients.Client(connectionId)
                                         .SendAsync("confirm", text, choices);
            var are = new AutoResetEvent(false);
            string response = null;
            void Callback(string connId, string message) {
                if (connectionId == connId) {
                    response = message;
                    are.Set();
                }
            }
            NotificationHub.Response += Callback;
            are.WaitOne(TimeSpan.FromSeconds(10));
            NotificationHub.Response -= Callback;
            return response;
        }
    }
Client side js:
    var conn = new signalR.HubConnectionBuilder().withUrl("/notification-hub").build();
    var connId;
    // using Noty v3 (https://ned.im/noty/)
    function confirm(text, choices) {
        return new Promise(function (resolve, reject) {
            var n = new Noty({
                text: text,
                timeout: 10000,
                buttons: choices.map(function (b) {
                    return Noty.button(b, 'btn', function () {
                        resolve(b);
                        n.close();
                    });
                })
            });
            n.show();
        });
    }
    conn.on('confirm', function(text, choices) {
        confirm(text, choices).then(function(choice) {
            conn.invoke("Callback", connId, choice);
        });
    });
    conn.start().then(function() {
        conn.invoke("ConnectionId").then(function (connectionId) {
            connId = connectionId;
            // Picked up by a form and posted to the server
            document.querySelector(".connection-id-input").value = connectionId;
        });
    });
For me this is way to complex to put it into the project i am working on.  
It really looks like something that will come back and bite you later...
