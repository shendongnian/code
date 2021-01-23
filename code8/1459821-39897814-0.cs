         static void Main(string[] args)
         {
               string apiKey = "your api key";
               string googleUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=43.038902,-87.906474&radius=500&type=restaurant&name=cruise&key=" + apiKey;
    
                WebRequest request = WebRequest.Create(googleUrl);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                //StreamWriter wr = new StreamWriter("json.txt");
                //wr.WriteLine(responseFromServer);
                //wr.Flush();
                //To see what it is inside json
                Result results = JsonConvert.DeserializeObject<Result>(responseFromServer);
    
                Console.WriteLine(responseFromServer);
                Console.ReadLine();
                reader.Close();
                dataStream.Close();
                response.Close();
    
            }
        }
    
        public class Result
        {
            public List<HTMLAttribution> html_attributions { get; set; }
            public string next_page_token { get; set; }
            public List<Place> results { get; set; }
            public string status { get; set; }
    
            //Definations of Classes
            public class HTMLAttribution { } //I don't what it is. It is empty for your url.
    
            public class Place
            {
                public Geometry geometry { get; set; }
                public string icon { get; set; }
                public string id { get; set; }
                public string name { get; set; }
                public OpeningHours opening_hours { get; set; }
                public List<Photo> photos { get; set; }
                public string place_id { get; set; }
                public int price_level { get; set; }
                public double rating { get; set; }
                public string reference { get; set; }
                public string scope { get; set; }
                public List<string> types { get; set; }
                public string vicinity { get; set; }
    
                public class Geometry
                {
                    public Location location { get; set; }
                    public Viewport viewport { get; set; }
                }
                public class Location
                {
                    public double lat { get; set; }
                    public double lng { get; set; }
                }
                public class Viewport
                {
                    public Northeast northeast { get; set; }
                    public Southwest southwest { get; set; }
                }
                public class Northeast
                {
                    public double lat { get; set; }
                    public double lng { get; set; }
                }
    
                public class Southwest
                {
                    public double lat { get; set; }
                    public double lng { get; set; }
                }
                public class OpeningHours
                {
                    public bool open_now { get; set; }
                    public List<object> weekday_text { get; set; }
                }
                public class Photo
                {
                    public int height { get; set; }
                    public List<string> html_attributions { get; set; }
                    public string photo_reference { get; set; }
                    public int width { get; set; }
                }
            }
        }
