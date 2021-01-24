using System;
using System.IO;
using RestSharp;
namespace RestSharpClient
{
	class Program
	{
		public const string baseUrl = "http://localhost:58610/api/values"; // <-- Change URL to yours!
		static void Main(string[] args)
		{
			Console.ReadKey();
			string tempFile = Path.GetTempFileName();
			using (var writer = File.OpenWrite(tempFile))
			{
				var client = new RestClient(baseUrl);
				var request = new RestRequest();
				request.ResponseWriter = (responseStream) => responseStream.CopyTo(writer);
				var response = client.DownloadData(request);
			}
			Console.ReadKey();
		}
	}
}
**Server**
My controlller:
