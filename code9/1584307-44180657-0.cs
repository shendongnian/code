    var settings = new Newtonsoft.Json.JsonSerializerSettings() 
                   {
                       DateTimeZoneHandling = DateTimeZoneHandling.Utc 
                   };
    var content=await objMyServices.GetData();
    var lstEvent = JsonConvert.DeserializeObject<List<EventModel>>(content, settings);
