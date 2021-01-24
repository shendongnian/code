    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    using System;
    using System.Collections.Generic;
    
    namespace kwcolson98
    {
        public class StockQuote
        {
            [JsonProperty("Time Series (Daily)")]
            public TimeSeriesDaily _TimeSeriesDaily { get; set; }
            public class TimeSeriesDaily
            {
                [JsonProperty("2017-06-01")]
                public TimeSeries _20170601 { get; set; }
    
                [JsonProperty("2017-05-31")]
                public TimeSeries _20170531 { get; set; }
                public class TimeSeries
                {
                    [JsonProperty("1. open")]
                    public string Open { get; set; }
    
                    [JsonProperty("2. high")]
                    public string High { get; set; }
    
                    [JsonProperty("3. low")]
                    public string Low { get; set; }
    
                    [JsonProperty("4. close")]
                    public string Close { get; set; }
    
                    [JsonProperty("5. volume")]
                    public string Volume { get; set; }
                }
            }
        }
    }
