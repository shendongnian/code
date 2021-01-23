    var manifest = new RequestDto();
    manifest.ClientId = "23824";
    var DeliveryDocumentInfo = new List<DeliveryDocument>();
    DeliveryDocumentInfo.Add(new DeliveryDocument { DocumentName = "Document Name", DocumentURL = "D:/Documnet/test.png" });
    manifest.DeliveryDocumentInfo = DeliveryDocumentInfo;
    var serOut = JsonConvert.SerializeObject(manifest);
    HttpContent content = new StringContent(serOut, Encoding.UTF8, "application/json");
    var responsesss = client.PostAsync(Constants.URLValue + "/api/Manifest", content).Result;
