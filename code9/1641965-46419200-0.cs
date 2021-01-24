    void Main()
    {
        LoginData obj = new LoginData
        {
            Username = "foo",
            Password = "Bar"
        };
        
        byte[] objBytes = Encoding.UTF8.GetBytes(obj.ToString());
        
    //    obj.OSVersion = deviceInformation.OperatingSystem;
    //    obj.DeviceModel = deviceInformation.FriendlyName;
        string URI = "https://XXXXXXXXX.azure-mobile.net/user/logsuserin";
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(URI, UriKind.RelativeOrAbsolute));
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Headers["applicationKey"] = "UFakeKkrayuAeVnoVAcjY54545455544";
        request.ContentLength = objBytes.Length;
        
        using (Stream stream = request.GetRequestStream())
        {
            stream.Write(objBytes, 0, objBytes.Length);
        }
        
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
        
    }
    
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OSVersion { get; set; }
        public string DeviceModel { get; set; }
        public override string ToString()
        {
            var temp = this.GetType()
                           .GetProperties()
                           .Select(p => $"{p.Name}={HttpUtility.UrlEncode(p.GetValue(this).ToString())}");
                           
            return string.Join("&", temp);
        }
    }
