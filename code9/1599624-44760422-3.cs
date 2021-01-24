	public IHttpActionResult Example2()
	{
		var stream = CreatePdf();
		return ResponseMessage(new HttpResponseMessage
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
		});
	}
