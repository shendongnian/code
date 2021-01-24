	using System;
	using System.IO;
	using System.Net.Http;
	using RestSharp;
	namespace Get2File
	{
		internal class Program
		{
			private const string FallbackUrl = @"https://httpbin.org/get";
			private static void Main(string[] args)
			{
				new Program().Get2FileWithRestSharp(fileExtensions:".xml");
			}
			private void Get2File(string altUrl = null, string fileExtensions = ".txt")
			{
				var url = !string.IsNullOrEmpty(altUrl)
					? altUrl
					: FallbackUrl;
				var client = new HttpClient();
				var content = client.GetStringAsync(url).Result;
				var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"File{fileExtensions}");
				File.WriteAllText(outputPath, content);
			}
			private void Get2FileWithRestSharp(string altUrl = null, string fileExtensions = ".txt")
			{
				var url = !string.IsNullOrEmpty(altUrl)
					? altUrl
					: FallbackUrl;
				var urlAsUri = new Uri(url);
				var client = new RestClient(urlAsUri);
				var request = new RestRequest(Method.GET);
				var content = string.Empty;
				var result = client.Execute(request);
				content = result.Content;
				var output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"File{fileExtensions}");
				File.WriteAllText(output, content);
			}
		}
	}
