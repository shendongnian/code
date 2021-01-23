	using System;
	using System.Net;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				string URL_status = "http://localhost/status";
				CredentialCache myCache = new CredentialCache();
				myCache.Add(new Uri(URL_status), "NTLM", new NetworkCredential("username", "password", "domain"));
				MyWebClient webClient = new MyWebClient();
				webClient.Credentials = myCache;
				for (int i = 1; i <= 5; i++)
				{
					string result = webClient.DownloadString(new Uri(URL_status));
					Console.WriteLine("Try {0}: {1}", i, result);
				}
				Console.Write("Done");
				Console.ReadKey();
			}
		}
		
		public class MyWebClient : WebClient
		{
			protected override WebRequest GetWebRequest(Uri address)
			{
				WebRequest request = base.GetWebRequest(address);
				if (request is HttpWebRequest) 
				{
					var myWebRequest = request as HttpWebRequest;
					myWebRequest.UnsafeAuthenticatedConnectionSharing = true;
					myWebRequest.KeepAlive = true;
				}
				return request;
			}
		} 	
	}
