    [HttpPost]
    public ContentResult ForwardCall(string called)
    {
       var response = new VoiceResponse();
       response.Dial(newNumber);
    
       return new ContentResult(TwiML(response), "text/xml");
    }
