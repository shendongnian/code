    private AssetTracker getAssetDetails(string deviceID)
    {
      var assetTracker = new AssetTracker { deviceid = deviceID };
     try
      {
       WebRequest req = WebRequest.Create(@"url");
       req.Method = "GET";
       req.Headers["Authorization"] = "Basic " + "a2VybmVsc3BoZXJlOmtlcm5lbHNwaGVyZQ==";
       HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
       var encoding = resp.CharacterSet == "" ? Encoding.UTF8 : Encoding.GetEncoding(resp.CharacterSet);
       using (var stream = resp.GetResponseStream())
        {
         var reader = new StreamReader(stream, encoding);
         var responseString = reader.ReadToEnd();
         var Pirs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<AssetDetail>>(responseString);
         var items = Pirs.Where(a => !a.dataFrame.EndsWith("AAAAAAAAAAA="))
          .GroupBy(a => a.dataFrame.Substring(a.dataFrame.Length - 12))
          .Select(g => g.First())                                                                 .OrderByDescending(a => a.timestamp).Take(10);
          foreach (var item in items)
            {
             byte[] data = Convert.FromBase64String(item.dataFrame.ToString());
             string hex = BitConverter.ToString(data);//converting base 64 to hexcode
             string formattedHex = BitConverter.ToString(data).Replace(@"-", string.Empty);
             string longitude = formattedHex.Substring(14, formattedHex.Length - 14);//04AC07EB
             long longitudeValue = Convert.ToInt64(longitude, 16);
             string longvalue = longitudeValue.ToString();
             longvalue = longvalue.Insert(2, ".");
             string latitude = formattedHex.Substring(6, formattedHex.Length - 14); //010A366B
             long lat = Convert.ToInt64(latitude, 16);
             string latvalue = lat.ToString();
             latvalue = latvalue.Insert(2, ".");
             assetTracker.latitude.Add(latvalue);
             assetTracker.longitude.Add(longvalue);
             }
             return assetTracker;
            }
          }   
        }
