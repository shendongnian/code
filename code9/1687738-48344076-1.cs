	[TestMethod]
	public async Task CheckSuccessfulUpload()
	{
		var baseAddress = new Uri("http://localhost:8000/");
		var config = new HttpSelfHostConfiguration(baseAddress);
		config.MapHttpAttributeRoutes();
		config.Routes.MapHttpRoute(
			name: "DefaultApi",
			routeTemplate: "api/{controller}/{id}",
			defaults: new { id = RouteParameter.Optional }
		);
		var server = new HttpSelfHostServer(config);
		var client = new HttpClient(server)
		{
			BaseAddress = baseAddress
		};
		const string fileUploadXML = "<?xml version=\"1.0\" encoding =\"utf8\"?>" +
			                            "<employees><employee id=\"1\" name=\"A\">" +
			                            "<employees><employee id=\"2\" name=\"B\">" +
			                            "<employees><employee id=\"3\" name=\"C\">" +
			                            "</employees>";
		var content = new ByteArrayContent(Encoding.UTF8.GetBytes(fileUploadXML));
		content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
		content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
		{
			Name = "file",
			FileName = "Employees.xml"
		};
		var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, "api/upload")
		{
			Content = new MultipartFormDataContent("----Boundry") { content }
		});
		Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
	}
