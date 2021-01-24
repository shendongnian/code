    public sealed class Persister : ReceiveActor
    {
        private readonly IInventorPersister inventorPersister;
        public Persister(IInventorPersister inventorPersister)
        {
            this.inventorPersister = inventorPersister;
            ReceiveAsync<CreatePublication>(async message =>
            {
                await Persist(message);
                Context.Sender.Tell("Success");
            });
        }
        private async Task Persist(CreatePublication message) { ... }
        ...
    }
