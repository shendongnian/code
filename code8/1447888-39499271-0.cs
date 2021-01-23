    string serviceCall = string.Format("{0}AttributeService.svc/AttributeDefinition/", _serviceLocation);
    
        int attributeIdInt = Convert.ToInt32(attributeId);
        int objectIdInt = Convert.ToInt32(objectId);
    
        AttributeContract attributeContract = new AttributeContract()
        {
            AttributeId = attributeIdInt,
            AttributeValue = attributeValue,
            ObjectId = objectIdInt,
            ObjectType = objectType
        };
     
                        var request =
                            (HttpWebRequest)
                                WebRequest.Create(new Uri(serviceCall );
                        request.ContentType = "application/json";
                        request.Method = "PUT";
                        var itemToSend = JsonConvert.SerializeObject(
                            attributeContract 
                            );
                        using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
                        {
                            streamWriter.Write(itemToSend);
                            streamWriter.Flush();
                            streamWriter.Dispose();
                        }
        
