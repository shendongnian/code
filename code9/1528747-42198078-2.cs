    string PostJsonToGivenUrl(string url, object jsonObject)
        {
            string resultOfPost = string.Empty;
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.ContentType = "application/json";
            httpRequest.Method = "POST";
            using (StreamWriter writer = new StreamWriter(httpRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(jsonObject);
                writer.Write(json);
            }
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                resultOfPost = streamReader.ReadToEnd();
            }
            return resultOfPost;
        }
