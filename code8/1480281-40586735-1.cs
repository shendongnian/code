    public class CardTextModel
    {
        public string prod_Code { get; set; }
        public string page1Text { get; set; }
        public string insideText { get; set; }
        public string userName { get; set; }
        public Nullable<System.DateTime> exportDate { get; set; }
        public List<CardTextModel> card_Text { get; set; }
    }
    public class CardTextModelRoot
    {
        public List<CardTextModel> card_Text {get;set;}
    }
    var content = @"{
          ""card_Text"": [
            {
              ""prod_Code"": ""G01Q0320WS"",
              ""page1Text"": ""SHORTY SET SZ 10"",
              ""insideText"": ""SHORTY SET SZ 10"",
              ""userName"": ""daz"",
              ""exportDate"": null
            },
            {
              ""prod_Code"": ""G01Q0380"",
              ""page1Text"": ""TREE DECS SET 4 RESIN"",
              ""insideText"": ""TREE DECS SET 4 RESIN"",
              ""userName"": ""mark"",
              ""exportDate"": null
            }
          ]
        }";
    
    var model = JsonConvert.DeserializeObject<CardTextModelRoot>(content);
