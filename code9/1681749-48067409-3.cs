    private static void Main(string[] args) {
        try {
            string cryptoCurrencyCode = "BTC";
            string countryCurrencyCode = "COP";
            string uri = string.Format("https://bitpay.com/rates/{0}/{1}", cryptoCurrencyCode, countryCurrencyCode);
            var client = new WebClient();
            client.UseDefaultCredentials = true;
            //Everything is returned inside of a "data" property, so let's select that token.
            string data = JObject.Parse(client.DownloadString(uri)).SelectToken("data").ToString();
            var rate = JsonConvert.DeserializeObject<RateModel>(data);
            Console.WriteLine("1 {0} = {1} {2}", cryptoCurrencyCode, rate.Rate, countryCurrencyCode);
        } catch (Exception ex) {
            Console.WriteLine("Caught exception: {0}", ex.ToString());
        } finally {
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
