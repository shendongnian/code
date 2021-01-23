    class InitializationCallbackAdapter
    {
        public Task OnInitialize()
        {
            this.StateManager.TryAddStateSerializer(new MyStateSerializer());
            return Task.FromResult(true);
        }
    
        public IReliableStateManager StateManager { get; set; }
    }
    
    class MyStatefulService : StatefulService
    {
        public MyStatefulService(StatefulServiceContext context)
            : this(context, new InitializationCallbackAdapter())
        {
        }
    
        public MyStatefulService(StatefulServiceContext context, InitializationCallbackAdapter adapter)
            : base(context, new ReliableStateManager(context, new ReliableStateManagerConfiguration(onInitializeStateSerializersEvent: adapter.OnInitialize)))
        {
            adapter.StateManager = this.StateManager;
        }
    }
