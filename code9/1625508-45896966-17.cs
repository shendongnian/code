    public class ChatHub : Hub {
        private IUserContextFactory userFactory;
    
        public ChatHub(IUserContextFactory userFactory) {
            this.userFactory = userFactory;
        }
    
        public void Send(string name, string message){
            var user = userFactory.Create(Context.User);
            var userId = user.UserId;
            //...        
        }
    }
