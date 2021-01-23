    // The name of the class may be not the most suitable in this case.
    public class Repo
    {
        public static async Task<T> GetAsync<T>(string uri)
        {
            var client = GetHttpClient(uri);
            var content = await client.GetStringAsync(uri);
            var serializer = new JavaScriptSerializer();
            var t = serializer.Deserialize<T>(content);
            return t;
        }
    }
    public Patron GetPatronById(string barcode)
    {
         string uri = "patrons/find?barcode=" + barcode;
         var Patron =  Repo.GetAsync<Patron>(uri).Result;
         return Patron;
    }
