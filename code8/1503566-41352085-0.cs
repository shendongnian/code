        public static async Task<string> messaging_server() {
        using (var messagebus1 = new TinyMessageBus("ExampleChannel"))
    
        {
    
            messagebus1.MessageReceived +=
            (sender, e) => 
            { 
                Debug.WriteLine(Encoding.UTF8.GetString(e.Message));
                return Encoding.UTF8.GetString(e.Message);
            } 
    
    
            while (true)
                {
                           #infinite loop        
            }
        }
    
    }
