	class MyService : IMyService
	{
		public string UserName {get;}
		// inject HttpContextBase
		public MyService(HttpContextBase context){
			this.UserName = context.User.Identity.Name;
		}
	}
