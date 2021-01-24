            string sURL = "https://sampleurl.com/api1/token";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            wrGETURL.Method = "POST";
            wrGETURL.ContentType = @"application/json; charset=utf-8";
            using (var stream = new StreamWriter(wrGETURL.GetRequestStream()))
            {
                var bodyContent = new
                {
                    username = "Actualusername",
                    password = "Actualpassword"
                }; // This will need to be changed to an actual class after finding what the specification sheet requires.
                var json = JsonConvert.SerializeObject(bodyContent);
                stream.Write(json);
            }
            HttpWebResponse webresponse = wrGETURL.GetResponse() as HttpWebResponse;
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            // read response stream from response object
            StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            // read string from stream data
            string strResult = loResponseStream.ReadToEnd();
            // close the stream object
            loResponseStream.Close();
            // close the response object
            webresponse.Close();
            Response.Write(strResult);
