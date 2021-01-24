       public HttpResponseMessage WebhookCallback(JContainer jsonData)
        {
            // Check to make sure we're getting an object not an array.
            if(jsonData.Type == JTokenType.Object)
            {
                var jObject = jsonData as JObject;
                // If this is an event type object parse it depending on the value of the info field.                
                if(jObject["event"] != null)
                {
                    
                    if (jObject["info"] != null && jObject["info"].ToString() == "REFRESH.INTERIM_PROGRESS")
                    {
                        InterimProgress interimProgress = Newtonsoft.Json.JsonConvert.DeserializeObject<InterimProgress>(jObject["data"].ToString());
                    }
                    if (jObject["info"] != null && jObject["info"].ToString() == "REFRESH.END_PROGRESS")
                    {
                        EndProgress interimProgress = Newtonsoft.Json.JsonConvert.DeserializeObject<EndProgress>(jObject["data"].ToString());
                    }
                }
                else if (jObject["providerAccount"] != null)
                {
                    ProviderAccount providerAccount = jObject.ToObject<ProviderAccount>();
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
