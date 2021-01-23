    private void RequestCompleted(IAsyncResult result)
    {
        var request = (HttpWebRequest)result.AsyncState;
        var response = (HttpWebResponse)request.EndGetResponse(result);
        JObject jdoc = null;
        Stream stream = response.GetResponseStream();
        try
        {
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            Regex rgx = new Regex("<.*\\>");
            string newResult = rgx.Replace(text, "");
            JObject json = JObject.Parse(newResult);
            jdoc = json;
            JArray results = (JArray)json["results"];
            if (results.Count == 0)
            {
                    
            }
            else
            {
                foreach(JObject obj in results)
                {
                   string formattedAddress = (string)obj["formatted_address"];
                   double lat = (double)obj["geometry"]["location"]["lat"];
                   double lng = (double)obj["geometry"]["location"]["lng"];
                }
            }                      
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error" + ex.Message);
        }
    }
