    namespace MyProject.Hubs
    {
        public class LiveHub : Hub
        {    
            public event Action SomethingHappened;
    
            public override Task OnConnected()
            {
                SomethingHappened?.Invoke();
                return base.OnConnected();
            }
        }
    }
