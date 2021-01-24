    [HttpPost]
    public virtual HttpResponseMessage Connect(string phoneNumber, string called)
    {
                string twiml = $"<?xml version=\"1.0\" encoding=\"utf-8\"?><Response><Dial callerId=\"{phoneNumber}\"><Client>support_agent</Client></Dial></Response>";
                var xmlResponse = new HttpResponseMessage();
                xmlResponse.Content = new StringContent(twiml, Encoding.UTF8, "text/xml");
    
                return xmlResponse;
    }
