    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Net;
    namespace test
    {
        class Program
        {
        public static void Main(string[] args)
        {
            try
            {
                string webAddr = "http://www.cibeg.com/_layouts/15/LINKDev.CIB.CurrenciesFunds/FundsCurrencies.aspx/GetCurrencies";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                httpWebRequest.Expect = "application/json";
                string datastring = "{\"lang\":\"en\"}";
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = encoder.GetBytes(datastring);
                httpWebRequest.ContentLength = data.Length;
                httpWebRequest.GetRequestStream().Write(data, 0, data.Length);
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    Console.WriteLine(responseText);
                    //Now you have your response.
                    //or false depending on information in the response     
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
