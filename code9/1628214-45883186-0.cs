    var client = new RestClient(uri);
    client.Authenticator = new NtlmAuthenticator();
    var requestCom = new RestRequest("", method);
    //add headers
    requestCom.AddHeader("Accept", "application/json");
    var body = new MyModel {
        AProperty = "Hello World!!!"
    }
    if (body != null) {
        requestCom.AddJsonBody(body);
    }
    IRestResponse response = client.Execute(requestCom);
