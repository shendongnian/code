    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Net;
	using System.Collections.Specialized;
	namespace HttpReq
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
	            try
	            {
	                using (var client = new WebClient())
	                {
	                    var postData = new NameValueCollection();
	                    postData["User"] = "Username";
	                    postData["Pass"] = "Password";
	                    var response = client.UploadValues("https://example.com/api.php", postData);
	                    var data = Encoding.Default.GetString(response);
	                    Console.WriteLine("Data from server: " + data);
	                    // Wait for key
	                    Console.ReadKey();
	                }
	            }
	            catch (Exception e)
	            {
	                Console.WriteLine(e);
	                Console.ReadKey();
	            }
	        }
	    }
	}
