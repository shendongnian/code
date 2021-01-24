            List<ServiceController> services = ServiceController.GetServices().ToList();
            ServiceController msQue = services.Find(o => o.ServiceName == "MSMQ");
            if (msQue != null) 
            {
                if (msQue.Status == ServiceControllerStatus.Running) 
                { 
                    // It is running.
                    
                    //Q Creation
                    if (MessageQueue.Exists(@".\Private$\TextsQueue"))
                    {
                        textsQueue = new System.Messaging.MessageQueue(@".\Private$\TextsQueue");
                       
                    }
                    else
                        textsQueue = MessageQueue.Create(@".\Private$\TextsQueue");
                    textsQueue.Purge();
                    textsQueue.ReceiveCompleted += new
                    ReceiveCompletedEventHandler(QueueReceiveCompleted);              
            }
