    public class ChatHub : Hub
	{
		private static List<Users> ConnectedUsers;
		
		public ChatHub()
		{
			ConnectedUsers = new List<Users>();
		}
		
		public override System.Threading.Tasks.Task OnConnected()
		{
			Clients.Caller.user(Context.User.Identity.Name);
			ConnectedUsers.Add(new Users(){
				UserName = Context.User.Identity.Name,
				ClientId = Context.clientID;
			});
			return base.OnConnected();
		}
		public void send(string message, string UserName)
		{
			
			//Clients.Caller.message("You:" + message); 
			var clientId = ConnectedUsers.FirstOrDefulat(x=>x.UserName == UserName).ClientId; // get from the static list by id you got		
			var scbscriber = Clients.Client(clientId);
			scbscriber.message(Context.User.Identity.Name + ": "message);
			
			//Clients.Others.message(Context.User.Identity.Name + ": " + message);
		}
		
	}
	public class Users
		{
			  public string UserName{get;set;}
			  public string ClientId {get;set;}
		}
