	using System;
	using System.IO;
	using System.Net.Http;
	namespace Get2File
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				new Program().Get2File();
			}
			private void Get2File(string altUrl = null)
			{
				var url = !String.IsNullOrEmpty(altUrl) 
					? altUrl
					: @"http://www.tuomas.salste.net/doc/roman/numeri-romani-1-5000.html";
				var client = new HttpClient();
				var content = client.GetStringAsync(url).Result;
				var outputPath = Path.Combine(AppContext.BaseDirectory, "File.txt");
				File.WriteAllText(outputPath, content);
			}
		}
	}
