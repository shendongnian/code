    class CurrencyJson
    {
         public string Id { get; set; }
        
         [JsonProperty("24h_volume_usd")]
         public string Volume_24h_Usd { get; set; }
         ...
    }
    
    class Currency
    {
        public string Id { get; set; }
        
        public string VolumeIn24h { get; set; }
    }
    
    async Task GetBitcoin()
    {
       
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("https://api.coinmarketcap.com/v1/ticker/?limit=1");
        HttpContent content = response.Content;
        //Read responce as String
        var readContent = await content.ReadAsStringAsync();
        //Deserialize string
        var desObject = JsonConvert.DeserializeObject<List<CurrencyWithStringProp>>(readContent);
        
        Mapper.Initialize(config =>
                {
                    config.CreateMap<CurrencyJson, Currency>()
                           .ForMember(d => d.VolumeIn24h, o => o.MapFrom(s => s.Volume_24h_Usd));
                });
         var currencies = Mapper.Map<IList<Currency>>(currencyJsons);         
    }
