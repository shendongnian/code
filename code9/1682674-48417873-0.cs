               string webpageContent = "";
               byte[] byteArray = Encoding.UTF8.GetBytes("value");
               HttpWebRequest webRequest (HttpWebRequest)WebRequest.Create(URL);
               webRequest.Method = "POST";
               webRequest.KeepAlive = true;
               webRequest.Timeout = 120000;
               System.Net.ServicePointManager.DefaultConnectionLimit = 3;
               webRequest.ContentType = "application/x-www-form-urlencoded";
               webRequest.ContentLength = byteArray.Length;
               using (Stream webpageStream = webRequest.GetRequestStream())
               {
                   webpageStream.Write(byteArray, 0, byteArray.Length);
               }
               using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
               {
                   using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                   {
                       webpageContent = reader.ReadToEnd();
                   }
               }
