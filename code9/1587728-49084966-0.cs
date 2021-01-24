    	using System;
		using System.Net.Http;
		using System.Text;
		using System.Threading.Tasks;
		using System.Net.Http.Headers;
		using Newtonsoft.Json;
		namespace NetsuiteConnector
		{
			class Netsuite
			{
				public void RunHttpTest()
				{
					Task t = new Task(TryConnect);
					t.Start();
					Console.WriteLine("Connecting to NS...");
					Console.ReadLine();
				}
				private static async void TryConnect()
				{
					// dummy payload
					String jsonString = JsonConvert.SerializeObject(
						new NewObj() {
							Name = "aname",
							Email = "someone@somewhere.com"
						}
					);
					
					string auth = "NLAuth nlauth_account=123456,nlauth_email=youremail@somewhere.com,nlauth_signature=yourpassword,nlauth_role=3";
					string url 	= "https://somerestleturl";
					var uri 	= new Uri(@url);
					HttpClient c = new HttpClient();
						c.BaseAddress = uri;
						c.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", auth);
						c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, url);
					req.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
					HttpResponseMessage httpResponseMessage = await c.SendAsync(req);
					httpResponseMessage.EnsureSuccessStatusCode();
					HttpContent httpContent = httpResponseMessage.Content;
					string responseString = await httpContent.ReadAsStringAsync();
					Console.WriteLine(responseString);
				}
			}
			class NewObj
			{
				public string Name { get; set; }
				public string Email { get; set; }
			}
		}
