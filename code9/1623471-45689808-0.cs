           public void Count(String path)
        {
            
                path = path.Remove(0, 21);
            try
           {
                PerformanceCounter queueCounter = new PerformanceCounter(
                 "MSMQ Queue",
                 "Messages in Queue",
                @path);
                
                Console.WriteLine("Queue contains {0} messages",
                    queueCounter.NextValue().ToString());
                myPrivateQueuesCount.Add((int)queueCounter.NextValue());
            }
            catch (Exception exc)
            {
                myPrivateQueuesCount.Add(0);
            }
            return;
        }
