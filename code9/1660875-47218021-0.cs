    class MySynchornizationContext : SynchronizationContext {
        public override void Post(SendOrPostCallback d, object state) {
            Console.WriteLine("posted");
            base.Post(d, state);
        }
        public override void Send(SendOrPostCallback d, object state) {
            Console.WriteLine("sent");
            base.Send(d, state);
        }
    }
