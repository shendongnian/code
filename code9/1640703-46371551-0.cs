         var events = 0
         private static void QueueRequestChanged()
        {           
            events++;           
            Task.Delay(10000).ContinueWith(t => Trigger());
        }
    
        private static void Trigger()
        {
                   if(events > 0)
                   {
                        events = 0;
                        // do code here
                   }
        }
