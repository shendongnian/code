      content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
      response = client.PostAsync(uri, content).Result;
      JSONString = response.Content.ReadAsStringAsync().Result;
      JSONString = JSONString.Replace("[", "");
      JSONString = JSONString.Replace("]", "");
      var definition = new { faceId = "" };
      var FaceGUID = JsonConvert.DeserializeAnonymousType(JSONString, definition);
      JSONString != "")
          FaceID = FaceGUID.faceId;
}
