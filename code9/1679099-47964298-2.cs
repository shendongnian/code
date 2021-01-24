    using System.Collections.Generic;
    using System.Net;
    
    using Newtonsoft.Json;
    
    namespace WhatToMine
    {
        using MineBlob = Dictionary<string, Dictionary<string, CoinBlob>>;
    
        class CoinBlob
        {
            [JsonProperty(PropertyName = "id")]
            public int Id;
            [JsonProperty(PropertyName = "tag")]
            public string Tag;
            [JsonProperty(PropertyName = "algorithm")]
            public string Algorithm;
            [JsonProperty(PropertyName = "block_time")]
            public double BlockTime;
            [JsonProperty(PropertyName = "block_reward")]
            public double BlockReward;
            [JsonProperty(PropertyName = "block_reward24")]
            public double BlockReward24;
            [JsonProperty(PropertyName = "last_block")]
            public long LastBlock;
            [JsonProperty(PropertyName = "difficulty")]
            public double Difficulty;
            [JsonProperty(PropertyName = "difficulty24")]
            public double Difficulty24;
            [JsonProperty(PropertyName = "nethash")]
            public long NetHash;
            [JsonProperty(PropertyName = "exchange_rate")]
            public double ExchangeRate;
            [JsonProperty(PropertyName = "exchange_rate24")]
            public double ExchangeRate24;
            [JsonProperty(PropertyName = "exchange_rate_vol")]
            public double ExchangeRateVolume;
            [JsonProperty(PropertyName = "exchange_rate_curr")]
            public string ExchangeRateCurrency;
            [JsonProperty(PropertyName = "market_cap")]
            public string MarketCapUsd;
            [JsonProperty(PropertyName = "estimated_rewards")]
            public string EstimatedRewards;
            [JsonProperty(PropertyName = "estimated_rewards24")]
            public string EstimatedRewards24;
            [JsonProperty(PropertyName = "btc_revenue")]
            public string BtcRevenue;
            [JsonProperty(PropertyName = "btc_revenue24")]
            public string BtcRevenue24;
            [JsonProperty(PropertyName = "profitability")]
            public double Profitability;
            [JsonProperty(PropertyName = "profitability24")]
            public double Profitability24;
            [JsonProperty(PropertyName = "lagging")]
            public bool IsLagging;
            [JsonProperty(PropertyName = "timestamp")]
            public long TimeStamp;
        }
    
        class Program
        {
            const string JsonUrl = "http://whattomine.com/coins.json";
    
            static void Main(string[] args)
            {
                using (var client = new WebClient()) {
                    var json = client.DownloadString(JsonUrl);
                    var blob = JsonConvert.DeserializeObject<MineBlob>(json);
                    // Do something with the data blob...
                }
            }
        }
    }
