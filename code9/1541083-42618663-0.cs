    var client = new TwilioRestClient(Environment.GetEnvironmentVariable(ssid), Environment.GetEnvironmentVariable(token));
    try {
    client.SendMessage(number, "+158965220", "Teting API message!");
    }
    catch(Exception e){
    // Exception
    }
