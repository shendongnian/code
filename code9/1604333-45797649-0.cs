    [HttpPost]
    public void Post([FromBody]JToken token)
    {
        if (token != null)
        {
            EventReg eventReg = new EventReg();
            if (token.Type == Newtonsoft.Json.Linq.JTokenType.Object)
            {
                eventReg.RegTime = DateTime.Now;
                foreach (var pair in token as Newtonsoft.Json.Linq.JObject)
                {
                    if (pair.Key == "EventID")
                    {
                        eventReg.EventId = pair.Value.ToString();
                    }
                    else if (pair.Key == "UserEmail")
                    {
                        eventReg.UserEmail = pair.Value.ToString();
                    }
                    else
                    {
                        eventReg.FormFields.Add(new BsonElement(pair.Key.ToString(), pair.Value.ToString()));
                     }
                }
            }
            //Add Registration:
            eventService.AddEventRegistration(eventReg);
        }
    }
