    public class ChatHub : Hub {
        private IUserContext user;
    
        public ChatHub(IUserContext user) {
            this.user = user;
        }
    
        public void Send(string name, string message){
            var userId = user.UserId;
            //...        
        }
    }
