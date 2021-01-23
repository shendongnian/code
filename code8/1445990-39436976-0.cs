    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var client = new TcpClient())
            {
                client.Connect("www.thecocktaildb.com", 80);
                string request = getRequestCoctail("margarita");
                using (var stream = client.GetStream())
                {
                    byte[] buffer = Encoding.Default.GetBytes(request);
                    stream.Write(buffer, 0, buffer.Length);
                    StringBuilder message = new StringBuilder();
                    int numberOfBytesRead = 0;
                    byte[] receiveBuffer = new byte[1024];
                    do
                    {
                        numberOfBytesRead = stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                        message.AppendFormat("{0}", Encoding.ASCII.GetString(receiveBuffer, 0, numberOfBytesRead));
                    } while (stream.DataAvailable);
                    string response = message.ToString();
                    response = response.Substring(response.IndexOf("\r\n\r\n"));
                    var drinks = JsonConvert.DeserializeObject<RootObject>(response);
                }
            }
        }
        private static string getRequestCoctail(string coctail)
        {
            return $"GET /api/json/v1/1/search.php?s=godfather HTTP/1.1\r\n"
                     + "Host: www.thecocktaildb.com\r\n\r\n";
        }
    }
    public class Drink
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strCategory { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public object strDrinkThumb { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }
        public string strIngredient11 { get; set; }
        public string strIngredient12 { get; set; }
        public string strIngredient13 { get; set; }
        public string strIngredient14 { get; set; }
        public string strIngredient15 { get; set; }
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public string strMeasure8 { get; set; }
        public string strMeasure9 { get; set; }
        public string strMeasure10 { get; set; }
        public string strMeasure11 { get; set; }
        public string strMeasure12 { get; set; }
        public string strMeasure13 { get; set; }
        public string strMeasure14 { get; set; }
        public string strMeasure15 { get; set; }
        public object dateModified { get; set; }
    }
    // used http://json2csharp.com/ to get an object from the json string
    public class RootObject
    {
        public List<Drink> drinks { get; set; }
    }
