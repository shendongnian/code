    public interface ICompanyProvider {
		string GetSchemaName();
	}
    public class CompanyProvider : ICompanyProvider {
		private readonly SharedDbContext _context;
		private readonly IHttpContextAccessor _accesor;
		private readonly UserManager<ApplicationUser> _userManager;
		public CompanyProvider(SharedDbContext context, IHttpContextAccessor accesor, UserManager<ApplicationUser> userManager) {
			_context = context;
			_accesor = accesor;
			_userManager = userManager;
		}
		public string GetSchemaName() {
			Task<ApplicationUser> getUserTask = null;
			Task.Run(() => {
				getUserTask = _userManager.GetUserAsync(_accesor.HttpContext?.User);
			}).Wait();
			var user = getUserTask.Result;
			if(user == null) {
				return "shared";
			}
			return _context.Companies.Single(c => c.Id == user.CompanyId).SchemaName;
		}
	}
