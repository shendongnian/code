       while (true) 
        { 
            try 
            { 
                //receive messages from Queue 
                message = queueClient.Receive(TimeSpan.FromSeconds(5)); 
                if (message != null) 
                { 
                    Console.WriteLine(string.Format("Message received: Id = {0}, Body = {1}", message.MessageId, message.GetBody<string>())); 
                    // Further custom message processing could go here… 
                    message.Complete(); 
                } 
                else 
                { 
                    //no more messages in the queue 
                    break; 
                } 
            } 
            catch (MessagingException e) 
            { 
                if (!e.IsTransient) 
                { 
                    Console.WriteLine(e.Message); 
                    throw; 
                } 
                else 
                { 
                    HandleTransientErrors(e); 
                } 
            } 
        } 
        queueClient.Close(); 
    }
