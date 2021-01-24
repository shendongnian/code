    var client = new RestClient(url);
    var request = new RestRequest("/placeTicket", Method.POST);
    request.RequestFormat = DataFormat.Json;
    var requestModel = JsonConvert.SerializeObject(model, new 
    JsonSerializerSettings { DateFormatHandling = 
    DateFormatHandling.MicrosoftDateFormat } )
    request.AddBody(model);
    var responseData = client.Execute(request).Content;
