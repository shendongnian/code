    string mycontent = await content.ReadAsStringAsync();
    var result= Newtonsoft.Json.JsonConvert.DeserializeObject<ApiResult>(mycontent);
    if (result!= null)
    {
         if (result.On)
         {
            //do something, may be read, result.Value
         }
         else
         {
             //do something else
         }                 
    }
