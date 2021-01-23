            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://myserver");
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    UserName = "<myUserName>",
                    Password = "<myPassword>"
                });
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }
