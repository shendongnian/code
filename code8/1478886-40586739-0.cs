    class MyClass
    {
        private bool isMailSent = false;
        async Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            if (this.isMailSent)
            {
                 // do whatever you want to do if a 2nd call is received
                 // while isMailSent
                 ProcessWhileIsMailSent(...)
            }
            else
            {   // called for the first time
                foreach (EventData eventData in messages)
                {
                    string data = ...
                    if (data == "mytestdata")
                    {
                        this.isMailSent = true;
                    // etc.
