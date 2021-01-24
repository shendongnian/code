    private void RequestCompleted(IAsyncResult result)
    {
        var request = (HttpWebRequest)result.AsyncState;
        var response = (HttpWebResponse)request.EndGetResponse(result);
        Stream stream = response.GetResponseStream();
        try
        {
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            Regex rgx = new Regex("<.*\\>");
            string newResult = rgx.Replace(text, "");
            JObject json = JObject.Parse(newResult);
            JArray results = (JArray)json["results"];
            List<double> latList = new List<double>();
            List<double> lngList = new List<double>();
            List<string> AddressList = new List<string>();
            if (results.Count == 0)
            {
                Dispatcher.BeginInvoke(new Action(() => MessageBox.Show("No results found")));
            }
            else
            {
                foreach (JObject obj in results)
                {
                    if (obj == null)
                    {
                        Dispatcher.Invoke(new Action(() => MessageBox.Show("Address returned no results")));
                    }
                    string formattedAddress = (string)obj["formatted_address"];
                    AddressList.Add(formattedAddress);
                    double lat = (double)obj["geometry"]["location"]["lat"];
                    latList.Add(lat);
                    double lng = (double)obj["geometry"]["location"]["lng"];
                    lngList.Add(lng);
                    //TODO Add exception handling
                }
                Dispatcher.Invoke(new Action(() => this.addressGrid.ItemsSource = AddressList));
            }
        }
        catch (Exception ex)
        {
            Dispatcher.Invoke(new Action(() => MessageBox.Show("Error" + ex.Message)));
        }
    }
