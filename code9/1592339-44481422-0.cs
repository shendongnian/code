    var output= DeserializeObject<string>(foo);
    
    var testing = JsonConvert.DeserializeObject<prayupapp.ModelClasses.PrayUpPrayers>(output,
                   new JsonSerializerSettings
                   {
                       NullValueHandling = NullValueHandling.Ignore
                   });
