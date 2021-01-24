    var json = JsonConvert.SerializeObject(ObjectOfTheClassToBeSerialized);
    var content = new StringContent(json, Encoding.UTF8, "application/json");
    HttpResponseMessage response = null;
                    
    response = await client.PostAsync(LinkToTheWebService, content);
    if (response.IsSuccessStatusCode){
         var item = await response.Content.ReadAsStringAsync();
         var result = JsonConvert.DeserializeObject<TypeOfTheClassToBeDeSerialized>(item);
    }
