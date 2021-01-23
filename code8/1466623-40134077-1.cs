        class ClaimsConverter : JsonCreationConverter<Claim>
        {
            protected override Claim Create(Type objectType, Newtonsoft.Json.Linq.JObject jObject)
            {
                    var type = jObject.Value<string>("Type");
                     var value = jObject.Value<string>("Value");
                  ....
                    return new Claim(type, value);
            }
            
        }
