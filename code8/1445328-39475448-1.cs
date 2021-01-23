	[Route("api/role")]
	public class RoleController : Controller {
		private readonly ISessionFactory SessionFactory;
		private readonly RoleServico RoleServico;
		public RoleController(ISessionFactory sessionFactory, RoleServico roleServico) {
		  if (sessionFactory == null)
			throw new ArgumentNullException("sessionFactory");
		  SessionFactory = sessionFactory;
		  this.RoleServico = roleServico;
		}
		[HttpGet]
		public IList<RoleModel> Get() {
		  IList<RoleModel> model = new List<RoleModel>();
		  using (var session = SessionFactory.OpenSession())
		  using (var transaction = session.BeginTransaction()) {
			return RoleServico.SelecionarRoles(session);
		  }
		}
	}
