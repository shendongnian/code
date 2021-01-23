			private async static Task DeleteValue(int id)
			{
				var url = "http://localhost:13628/api/Values/" + id;
				using (var client = new HttpClient())
				{
					var response = await client.DeleteAsync(url);
					if (response.IsSuccessStatusCode)
					{
						await ReadValues();
					}
					else
					{
						var errorMessage = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
						// Here Newtonsoft.Json Package is used to deserialize response content 
						Console.WriteLine(errorMessage);
						Console.WriteLine(response.StatusCode);
					}
				}
			}
	
