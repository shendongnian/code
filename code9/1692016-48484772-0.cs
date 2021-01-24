    RootObject result = JsonConvert.DeserializeObject<RootObject>(json.Content);
    JToken dataToken = JObject.Parse(json.Content).SelectToken("data");
    int i = 0;
    foreach (JProperty property in dataToken.Children().SelectMany(child => ((JObject)child).Properties()))
    {
        result.data[i++].GpsOdometro =
            new Dictionary<string, GpsOdometro>
            {
                { property.Name, JObject.Parse(o2.ToString()).SelectToken(property.Path).ToObject<GpsOdometro>() }
            };
    }
