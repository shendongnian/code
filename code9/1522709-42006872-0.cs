    class Program
    {
        static void Main(string[] args)
        {
            GetCountryByIP();
        }
        public static void GetCountryByIP()
        {
            IpInfo ipInfo = new IpInfo();
            string info = new WebClient().DownloadString("http://ipinfo.io");
            JavaScriptSerializer jsonObject = new JavaScriptSerializer();
            ipInfo = jsonObject.Deserialize<IpInfo>(info);
            RegionInfo region = new RegionInfo(ipInfo.Country);
            Console.WriteLine(region.EnglishName);
            Console.ReadLine();
        }
        public class IpInfo
        {
            //country
            public string Country { get; set; }
        }
    }
