            listener = new DatagramSocket();
            listener.MessageReceived += MessageReceived;
            listener.Control.InboundBufferSizeInBytes = 1;
            
            await listener.BindServiceNameAsync("1337");
