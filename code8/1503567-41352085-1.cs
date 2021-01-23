        public static async Task<string> messaging_server() {
        using (var messagebus1 = new TinyMessageBus("ExampleChannel"))
    
        {
    
            messagebus1.MessageReceived +=
            (sender, e) => 
            { 
                var encodedMessage = Encoding.UTF8.GetString(e.Message);
                Debug.WriteLine(encodedMessage);
                return encodedMessage;
            } 
    
    
            while (true)
            {
                #infinite loop        
            }
        }
    
    }
