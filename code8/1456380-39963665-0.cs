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
				MyWebClient WebClient = new MyWebClient();
				WebClient.Credentials = myCache;
				for (int i = 1; i <= 5; i++)
				{
					string Result = WebClient.DownloadString(new Uri(URL_status));
					Console.WriteLine("Try " + i.ToString() + ": " + Result);
				}
				Console.Write("Done");
				Console.ReadKey();
			}
		}
		
		public class MyWebClient : WebClient
		{
			protected override WebRequest GetWebRequest(Uri address)
			{
				WebRequest request = (WebRequest)base.GetWebRequest(address);
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
