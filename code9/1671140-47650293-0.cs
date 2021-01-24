	ResponseMessageResult responseMessageResult;
    using (MemoryStream stream = new MemoryStream(textAsBytes))
    using (HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK))
	{
	    httpResponseMessage.Content = new StreamContent(stream);
	    httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
	    {
	        FileName = "main-theme.scss"
	    };
	    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/css");
	    responseMessageResult = ResponseMessage(httpResponseMessage);
	}
    return responseMessageResult;
