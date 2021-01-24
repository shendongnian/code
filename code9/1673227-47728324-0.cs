    [HttpPost]
    [Route("")]
    public void Post(JObject message)
    {
        var dynamicMessage = (dynamic)message;
        var status = dynamicMessage.status;
        var title = dynamicMessage.title;            
    }
