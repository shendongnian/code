    String AzureURL = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect";
    String FaceID = "";
    
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriotionKey);
    string queryString = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender";
    
    queryString = "returnFaceId=true&returnFaceLandmarks=false";
    string uri = AzureURL + "?" + queryString;
    
    HttpResponseMessage response;
    string JSONString;
    
    
    using (var content = new ByteArrayContent(ImageBytes))
    {
          content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
          response = client.PostAsync(uri, content).Result;
          JSONString = response.Content.ReadAsStringAsync().Result;
    
          JSONString = JSONString.Replace("[", "");
          JSONString = JSONString.Replace("]", "");
    
          var definition = new { faceId = "" };
          var FaceGUID = JsonConvert.DeserializeAnonymousType(JSONString, definition);
    
          if(JSONString != "")
              FaceID = FaceGUID.faceId;
    }
