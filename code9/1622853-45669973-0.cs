            using (var content = new MultipartFormDataContent())
			{
				var fileNameOnly = Path.GetFileName(fileName);
				var fileContent = new StreamContent(File.OpenRead(fileName));
				fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
				{
					Name = $"files[{fileNameOnly}]",
					FileName = fileNameOnly
				};
				fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/pot"); // "gettext" POT format
				
				content.Add(fileContent, $"files[{fileNameOnly}]");
				content.Add(new StringContent("gettext"), "type");
				var statusResult = client.PostAsync(addUrl, content).Result;
				var statusString = statusResult.Content.ReadAsStringAsync().Result;
			}
