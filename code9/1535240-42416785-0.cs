	[HttpGet]
	[AllowAnonymous]
	[Route(template: "Reward/FooLogo/{fooId}/bar/{barId}", Name = "FooLogo")]
	public async Task<HttpResponseMessage> FooLogo(int fooId, int barId)
	{
		var foo = await GetFooAsync(fooId, barId);
		if (string.IsNullOrWhiteSpace(foo?.ImageUrl))
		{
			throw new HttpResponseException(HttpStatusCode.NotFound);
		}
		using (var client = new HttpClient())
		{
			var res = await client.GetAsync(paymentMethod.ImageUrl);
			var response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StreamContent(await res.Content.ReadAsStreamAsync());
			response.Content.Headers.ContentType = res.Content.Headers.ContentType;
			return response;
		}
	}
