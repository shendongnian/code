    using System; 
    using System.IO; 
    using System.Net; 
    using System.Text; 
 
    namespace Examples.System.Net 
    { 
        public class WebRequestGetExample 
        { 
            public static void Main () 
            { 
                // Get the object used to communicate with the server. 
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://000.000.000.000/home/reallycoolplacewithstuffIneed"); 
                request.Method = WebRequestMethods.Ftp.DownloadFile; 
 
                // Trying to use your credentials 
                request.Credentials = new NetworkCredential("USERNAME","PASSWORD"); 
 
                FtpWebResponse response = (FtpWebResponse)request.GetResponse(); 
 
                Stream responseStream = response.GetResponseStream(); 
                StreamReader reader = new StreamReader(responseStream); 
                Console.WriteLine(reader.ReadToEnd()); 
 
                Console.WriteLine("Download Complete, status {0}", response.StatusDescription); 
 
                reader.Close(); 
                response.Close();   
            } 
        } 
    }
