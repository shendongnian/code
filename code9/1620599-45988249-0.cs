    using SimpleSOAPClient;
    using SimpleSOAPClient.Handlers;
    using SimpleSOAPClient.Helpers;
    using SimpleSOAPClient.Models;
    using SimpleSOAPClient.Models.Headers;
    ...
    _client = SoapClient.Prepare().WithHandler(new DelegatingSoapHandler());
    _client.HttpClient.DefaultRequestHeaders.Clear();
    _client.HttpClient.DefaultRequestHeaders.Add("SOAPAction", "Action...");
     var requestEnvelope = SoapEnvelope
         .Prepare()
         .Body(request)
         .WithHeaders(KnownHeader.Oasis.Security.UsernameTokenAndPasswordText(Username, Password));
    var responseEnvelope = _client.Send(Url, "CanNotBeEmpty", requestEnvelope);
