	public class CustomersController : ApiController
	{
		[Route("api/v2/customers", Order = 2)]
		[ResponseType(typeof(CustomerCollection))]
		public IHttpActionResult Get()
		{
			...
		}
		[Route("api/v2/customers/{identifier}", Order = 1)]
		[ResponseType(typeof(Customer))]
		public IHttpActionResult Get(string identifier)
		{
			...
		}
	}
