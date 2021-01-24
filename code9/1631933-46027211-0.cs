	public class CreateParameters
	{
		public Person Person { get; set; }
		public Category Category { get; set; }
	}
---
	[HttpPost]
	[Route("Create")]
	public IHttpActionResult Create(CreateParameters parameters)
	{
		try
		{
			new PersonBLL().Create(parameters.Person, parameters.Category);
			return Ok("success");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
