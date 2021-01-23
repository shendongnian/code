     public class CardsModel
        {
            public List<CardTextModel> card_Text { get; set; }
        }
        public class CardTextModel
        {
            public string prod_Code { get; set; }
            public string page1Text { get; set; }
            public string insideText { get; set; }
            public string userName { get; set; }
            public Nullable<System.DateTime> exportDate { get; set; }
            public List<CardTextModel> card_Text { get; set; }
        }
    var model = JsonConvert.DeserializeObject<CardsModel>(content);
