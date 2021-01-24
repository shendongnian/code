		public class MyController : Controller
		{
			private readonly UnitOfWork _unitOfWork;
			private readonly ClientRepository _clientRepository;
			
			public MyController(UnitOfWork unitOfWork, ClientRepository clientRepository)
			{
				_unitOfWork = unitOfWork;
				_clientRepository = clientRepository;
			}
			
			//When you are calling action DoSomething, you don't have to worry about constructor params (DI will pass them)
			public ActionResult DoSomething()
			{
				_clientRepository.DoSomething();
				return PartialView("DoSomething");
			}
		}
