	public interface IUserProvider
	{
		public string GetUserId();
	}
	public class UserProvider : IUserProvider
	{
		public string GetUserId()
		{
			return User.Identity.GetUserId();
		}
	}
	public class SomeController
	{
		private IUserProvider UserProvider { get; set;}
		public SomeController(IUserProvider userProvider)
		{
			UserProvider = userProvider;
		}
		[Authorize]
		[HttpGet]
		[Route("api/UserProject/GetUserProjects")]
		public HttpResponseMessage GetProjects()
		{
			string userId = UserProvider.GetUserId();
			if (!ModelState.IsValid)
			{
				return new HttpResponseMessage(HttpStatusCode.BadRequest);
			}
			try
			{
				List<ProjectDto> userProjectsDtos = projectBll.GetProjects(userId);
				return Request.CreateResponse(HttpStatusCode.OK, userProjectsDtos);
			 }
			 catch (Exception)
			 {
				return new HttpResponseMessage(HttpStatusCode.InternalServerError);
			 }
		}
	}
