    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Net;
    
    namespace doPostExampleForStackOverflow
    {
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string postReturn = doPostCall();
			MessageBox.Show(postReturn);
			Application.Exit();
        }
		static string doPostCall()
        {
            string URI = "https://webserver.com/post.php";
            string myParameters = "username=" + Environment.UserName; /* Get local username (Windows) */
                string result;
    
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    result = wc.UploadString(URI, myParameters);
                }
                if (result.Length <= 0) {
                    return "Nothing came back from the webserver.";
                } else {
                    return result;
                }
            }
        }
    }
