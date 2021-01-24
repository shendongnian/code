    using System;
	using System.Web;
	using System.Net;
	using System.IO;
	using System.Text;
						
	public class Program
	{
		public static void Main()
		{
			var result = String.Empty;
			
			var urlPaginaHtml = "https://example.com/trabajo-abogado-civil/A-Coru%25C3%25B1a-guti%25C3%25A9rrez";
			urlPaginaHtml = HttpUtility.UrlDecode(HttpUtility.UrlDecode(urlPaginaHtml));
			
			//urlPaginaHtml = "https://www.google.com.br/"; <-- WORKS
			
			Console.WriteLine("URL: " +urlPaginaHtml);
			
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlPaginaHtml);
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				
				if (response.StatusCode == HttpStatusCode.OK)
				{
					Stream receiveStream = response.GetResponseStream();
					StreamReader readStream = null;
					
					if (response.CharacterSet == null)
					{
						readStream = new StreamReader(receiveStream);
					}
					else
					{
						readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
					}
					
					//var data = readStream.ReadToEnd();
					result = readStream.ReadToEnd();
					
					response.Close();
					readStream.Close();
					
					//MessageBox.Show(data);
					//return data;
				}
				else
				{
					//return ""; 
				}
				Console.WriteLine("DONE!!!");
				Console.WriteLine(result);
			}
			catch (WebException e)
			{
				Console.WriteLine("#ERROR#: " + e.Message);
			}
		}
	}
