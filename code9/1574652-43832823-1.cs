	using System;
	using System.IO;
	using System.Net;
	using System.Net.Http;
	using RestSharp;
	namespace Get2File
	{
		internal class Program
		{
			private const string FallbackUrl = @"";
			private static void Main(string[] args)
			{
				new Program().Get2File();
			}
			private void Get2File(string altUrl = null)
			{
				var url = !String.IsNullOrEmpty(altUrl) 
					? altUrl
					: FallbackUrl;
				var client = new HttpClient();
				var content = client.GetStringAsync(url).Result;
				var outputPath = Path.Combine(AppContext.BaseDirectory, "File.txt");
				File.WriteAllText(outputPath, content);
			}
			private void Get2FileWithRestSharp(string altUrl = null)
			{
				var url = !String.IsNullOrEmpty(altUrl)
					? altUrl
					: FallbackUrl;
				Uri urlAsUri = new Uri(url);
				RestClient client = new RestClient();
				RestRequest request = new RestRequest(urlAsUri, Method.GET);
				string content = String.Empty;
				var result = client.ExecuteAsync(request, response =>
				{
					content = response.Content;
				}).WebRequest.GetResponseAsync().Result;
				string output = Path.Combine(AppContext.BaseDirectory, "File.txt");
				File.WriteAllText(output, content);
			}
		}
	}
