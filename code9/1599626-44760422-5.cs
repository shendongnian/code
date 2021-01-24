	public HttpResponseMessage ExampleOne()
	{
		var stream = CreatePdf();
		return new HttpResponseMessage
		{
			Content = new StreamContent(stream)
			{
				Headers =
				{
					ContentType = new MediaTypeHeaderValue("application/pdf"),
					ContentDisposition = new ContentDispositionHeaderValue("attachment")
					{
						FileName = "myfile.pdf"
					}
				}
			},
			StatusCode = HttpStatusCode.OK
		};
	}
