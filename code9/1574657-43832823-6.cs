	using System;
	using System.Diagnostics;
	using System.IO;
	using System.Net.Http;
	using System.Xml.Linq;
	using System.Linq;
	using RestSharp;
	namespace Get2File
	{
		internal class Program
		{
			private const string FallbackUrl = @"https://gist.github.com/Rusk85/8d189cd35295cfbd272d8c2121110e38/raw/4885d9ba37528faab50d9307f76800e2e1121ea2/example-xml-with-embedded-html.xml";
			private string _downloadedContent = null;
			private const string FileNameWithoutExtension = "File";
			private static void Main(string[] args)
			{
				var p = new Program();
				p.Get2FileWithRestSharp(fileExtensions:".xml");
				p.UseLinq2XmlOnFile();
			}
			private void Get2File(string altUrl = null, string fileExtensions = ".txt")
			{
				var url = !string.IsNullOrEmpty(altUrl)
					? altUrl
					: FallbackUrl;
				var client = new HttpClient();
				var content = client.GetStringAsync(url).Result;
				_downloadedContent = content;
				var outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{FileNameWithoutExtension}{fileExtensions}");
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
				_downloadedContent = content;
				var output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{FileNameWithoutExtension}{fileExtensions}");
				File.WriteAllText(output, content);
			}
			private void UseLinq2XmlOnFile()
			{
				XElement xElement = XElement.Parse(_downloadedContent);
				var elements = xElement.Elements();
				var StringElement = elements.FirstOrDefault(e => e.Name == "String");
				var tranlateXAttribute = StringElement.Attributes().FirstOrDefault(attr => attr.Name == "translate");
				Debug.WriteLine(tranlateXAttribute.Value);
			}
		}
	}
