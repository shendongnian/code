    public static void getSavedHtmlCode()
        {
            string html = string.Empty;
            
            try
            {
                var request = System.Net.HttpWebRequest.Create(string.Format("{0}", "https://www.w3schools.com/html/default.asp"));
                request.Method = "GET";
                var response = (HttpWebResponse)request.GetResponse();
                //prepare as html
                //html = new StreamReader(response.GetResponseStream()).ReadToEnd();
                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();
                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                //prepare as html
                html = readStream.ReadToEnd();
                Console.WriteLine("Response stream received.");
                Console.WriteLine(html);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
