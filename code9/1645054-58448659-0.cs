    using System;
    using System.IO;
    using System.Net;
    
    namespace gMIS.Rendering
    {
        public static class RazorPage
        {
            public static string RenderToString(string url)
            {
                try
                {
                    //Grab page
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    Stream data = response.GetResponseStream();
                    string html = String.Empty;
                    using (StreamReader sr = new StreamReader(data))
                    {
                        html = sr.ReadToEnd();
                    }
                    return html;
                }
                catch (Exception err)
                {
                    return {Handle as you see fit};
                }
            }
        }
    }
