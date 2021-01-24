    public class Program {
    
        public static DiscordClient client;
    
        static void Main(string[] args) {
    
            // Create a discord client
            client = new DiscordClient(x => {
    
                    x.AppName = "Your App Name";
    
                    x.AppUrl = "";
    
                    x.MessageCacheSize = 0;
    
                    x.UsePermissionsCache = true;
    
                    x.EnablePreUpdateEvents = true;
    
                    x.LogLevel = LogSeverity.Debug;
    
                    x.LogHandler = OnLogMessage;
    
                    });
    
            // Assign a callback to the MessageRecieved event on client
            client.MessageReceived += OnMessageRecieved;
    
        }
    
        // Our MessageRecieved callback
        public static void OnMessageRecieved(object sender, MessageEventArgs args) {
            // Your code to handle messages here, the message string can be accessed by args.Message.Text
        }
    
    }
