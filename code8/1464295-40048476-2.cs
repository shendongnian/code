      String jsonData;
                string url =
                    String.Format(
                        @" http://localhost:37266/api/Default/GetCars");
    
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
    
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        jsonData = reader.ReadToEnd();
                    }
    
                    //Console.WriteLine(jsonData);
                }
                var cars = new JavaScriptSerializer().Deserialize<List<Cars>>(jsonData);
                var ss = cars;
