	[HttpPost]
	public StatusCodeResult Post(IFormFile file)
	{
		try
		{
			if (file != null && file.Length > 0)
			{
				using (var client = new HttpClient())
				{
					try
					{
						client.BaseAddress = new Uri(currentPrivateBackendAddress);
						
						byte[] data;
						using (var br = new BinaryReader(file.OpenReadStream()))
							data = br.ReadBytes((int)file.OpenReadStream().Length);
						ByteArrayContent bytes = new ByteArrayContent(data);
						
						MultipartFormDataContent multiContent = new MultipartFormDataContent();
						
						multiContent.Add(bytes, "file", file.FileName);
						var result = client.PostAsync("api/Values", multiContent).Result;
						
						return StatusCode((int)result.StatusCode); //201 Created the request has been fulfilled, resulting in the creation of a new resource.
													
					}
					catch (Exception)
					{
						return StatusCode(500); // 500 is generic server error
					}
				}
			}
			return StatusCode(400); // 400 is bad request
		}
		catch (Exception)
		{
			return StatusCode(500); // 500 is generic server error
		}
	}
	
	
