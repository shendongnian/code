	[HttpPost]
	public async Task<IActionResult> Index(ICollection<IFormFile> files)
	{
		using (var client = new HttpClient())
		{
			client.BaseAddress = new Uri(_options.SiteSpecificUrl);
			foreach (var file in files)
			{
				if (file.Length <= 0)
					continue;
				var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
				using (var content = new MultipartFormDataContent())
				{
					content.Add(new StreamContent(file.OpenReadStream())
					{
						Headers =
						{
							ContentLength = file.Length,
							ContentType = new MediaTypeHeaderValue(file.ContentType)
						}
					}, "File", fileName);
					var response = await client.PostAsync(_options.WebApiPortionOfUrl, content);
				}
			}
		}
	}
