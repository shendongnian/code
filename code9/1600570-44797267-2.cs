	[MyControllerConfig("ai", "www.something.org")]
	public class MyController : ApiController
	{
		[HttpGet]
		[Route("test")]
		public IHttpActionResult Testing()
		{
			return Ok(new Test("Ann"));
		}
	}
	public class Ns
	{
		public const string Ai = "www.something.org";
	}
	[XmlRoot(ElementName = "test")]
	public class Test
	{
		[XmlElement(ElementName = "name", Namespace = Ns.Ai)]
		public string Name { get; set; }
		public Test(string name)
		{
			Name = name;
		}
		public Test() { }
	}
