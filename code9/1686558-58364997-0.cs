    public enum Channel
    {
        [EnumMember(Value = "ticker")]
        TICKER,
        [EnumMember(Value = "book")]
        BOOK,
        [EnumMember(Value = "trade")]
        TRADES
    }
    
    
    public class Response
    {
        [JsonProperty("channel")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Channel Channel { get; set; }
    }
    
    public class TradeResponse : Response
    {
        public string Symbol;
        public DateTime time;
        ...
    }
    
    public override void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e)
    {
        Response res = JsonConvert.DeserializeObject<Response>(e.Message.ToString());
    
        switch (res.Channel)
        {
            case Channel.TRADES:
                TradeResponse trade = JsonConvert.DeserializeObject<TradeResponse>(e.Message.ToString());
                // ...
                break;
            case Channel.BOOK:
                break;
            case Channel.TICKER:
                break;
            default:
                throw new System.Exception("Unsupported channel");
        }
    
        Console.WriteLine(e.Message.ToString());
    }
