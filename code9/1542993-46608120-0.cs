    public IActionResult MyAction ([FromBody] PayloadObject payloadObject)
    {
        //create a dictionary to store the json string
        var customDataDict = new Dictionary<string, string>();
        
        //convert the object to a json string
        string activationRequestJson = JsonConvert.SerializeObject(
        new
        {
            payloadObject = payloadObject
        });
        
        customDataDict.Add("body", activationRequestJson);
        //Track this event, with the json string, in Application Insights
        telemetryClient.TrackEvent("MyAction", customDataDict);
        return Ok();
    }
