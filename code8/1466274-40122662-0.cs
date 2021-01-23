          var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateParseHandling = DateParseHandling.None
            };
           List<Claim> claims =JsonConvert.DeserializeObject<List<Claim>>(serializedClaims, settings);
