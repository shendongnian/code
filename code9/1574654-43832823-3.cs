	using System;
	using System.IO;
	using System.Net.Http;
	using RestSharp;
	namespace Get2File
	{
		internal class Program
		{
			private const string FallbackUrl = @"https://gist.github.com/Rusk85/3639772c01c5ee3283a685d58ca690ea/raw/0c45329b9b0dadd79390a3e6246c891a0dee0c4b/File.txt";
			private static void Main(string[] args)
			{
				new Program().Get2FileWithRestSharp();
			}
			private void Get2File(string altUrl = null)
			{
				var url = !string.IsNullOrEmpty(altUrl)
					? altUrl
					: FallbackUrl;
				var client = new HttpClient();
				var content = client.GetStringAsync(url).Result;
				var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File.txt");
				File.WriteAllText(outputPath, content);
			}
			private void Get2FileWithRestSharp(string altUrl = null)
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
				var output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File.txt");
				File.WriteAllText(output, content);
			}
		}
	}
