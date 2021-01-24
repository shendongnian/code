     List<string> newEvent = new List<string>();
            newEvent.Add(msg.Split('|')[1]);
            newEvent.Add(msg.Split('|')[2]);
            newEvent.Add(msg.Split('|')[3]);
            newEvent.Add(msg.Split('|')[4]);
            newEvent.Add(msg.Split('|')[5]);
            
            JArray newEventJsonItem = new JArray(newEvent);//Convert newEvent to JArray.
        
            JObject jsonObject = JObject.Parse(File.ReadAllText("data.json"));
           
            JArray incomingEvents = jsonObject["incomingEvents"].Value<JArray>();
           
            incomingEvents.Add(newEventJsonItem );//Insert new JArray object.
             
            Console.WriteLine(JsonConvert.SerializeObject(incomingEvents, Formatting.Indented));
