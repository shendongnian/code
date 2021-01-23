    public static async Task<string> messaging_server() 
    {
        string ret;
        using (var messagebus1 = new TinyMessageBus("ExampleChannel"))  
        {
            messagebus1.MessageReceived += (sender, e) => 
            {
                ret = Encoding.UTF8.GetString(e.Message);
                Debug.writeLine(ret);
            });
            while (true)
            {
                //#infinite loop        
            }
        }  
 
        return ret;
    } 
