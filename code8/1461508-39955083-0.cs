            bool pingable = false;
            Ping pingObject = new Ping();
           
            PingReply reply = pingObject.Send("127.0.0.1");
            pingable = reply.Status == IPStatus.Success;
         
