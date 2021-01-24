    public class ChatHub : Hub {
        private IUserContext user;
        public override Task OnConnected() {
            user = GetAuthInfo();
            return Clients.All.joined(user);;
        }
        protected IUserContext GetAuthInfo() {
            var user = Context.User;
            return new UserContext(user);
        }
    
        public void Send(string name, string message){
            var userId = user.UserId;
            //...        
        }
    }
