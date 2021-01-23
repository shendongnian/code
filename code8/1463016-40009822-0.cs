	using Newtonsoft.Json;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;
	using System.Web;
	using System.Web.Helpers;
	using System.Web.Mvc;
	namespace DocumentManager.UI
	{
		public class ApiClient<T>
		{
			public ApiClientErrorTypes Error{get;private set;}
			private string baseUri =  @"http://localhost/DocumentManager.WebAPI/";
			
			public T ApiGet(string requestUrl)
			{
				using (var client = new HttpClient())
				{
					var requestUri = new Uri(baseUri + requestUrl);
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					if (ApiAuthToken.token != null)
					{
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiAuthToken.token.ToString());
					}
					var response = client.GetAsync(requestUri).Result;
					string contentString = response.Content.ReadAsStringAsync().Result;
					if (response.IsSuccessStatusCode)
					{
						T result = JsonConvert.DeserializeObject<T>(contentString);
						return result;
					}
					if (int.Parse(response.StatusCode.ToString()) > 400 && int.Parse(response.StatusCode.ToString()) <= 499)
						Error = ApiClientErrorTypes.UnAuthorised;
					else
						Error = ApiClientErrorTypes.Technical;
					return default(T);
				}
			}
			public T ApiPost(string requestUrl, HttpContent encodedContent)
			{
				using(var client = new HttpClient())
				{
					var requestUri = new Uri(baseUri + requestUrl);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					if (ApiAuthToken.token != null)
					{
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiAuthToken.token.ToString());
					}
					var response = client.PostAsync(requestUri, encodedContent).Result;
					string contentString = response.Content.ReadAsStringAsync().Result;
					if (response.IsSuccessStatusCode)
					{
						T result = JsonConvert.DeserializeObject<T>(contentString);
						return result;
					}
					if (int.Parse(response.StatusCode.ToString()) > 400 && int.Parse(response.StatusCode.ToString()) <= 499)
						Error = ApiClientErrorTypes.UnAuthorised;
					else
						Error = ApiClientErrorTypes.Technical;
					return default(T);
				}
			}
			public bool ApiPostBool(string requestUrl, HttpContent encodedContent)
			{
				using (var client = new HttpClient())
				{
					var requestUri = new Uri(baseUri + requestUrl);
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					if (ApiAuthToken.token != null)
					{
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiAuthToken.token.ToString());
					}
					var response = client.PostAsync(requestUri, encodedContent).Result;
					string contentString = response.Content.ReadAsStringAsync().Result;
					if (response.IsSuccessStatusCode)
					{
						return true;
					}
					return false;
				}
			}
		}
	}
