    X509Certificate2 certificate;
    var handler = new HttpClientHandler {
        ClientCertificateOptions = ClientCertificateOption.Manual,
        SslProtocols = SslProtocols.Tls12
    };
    handler.ClientCertificates.Add(certificate);
    handler.CheckCertificateRevocationList = false;
    // this is required to get around self-signed certs
    handler.ServerCertificateCustomValidationCallback =
        (httpRequestMessage, cert, cetChain, policyErrors) => {
            return true;
        };
    var client = new HttpClient(handler);
    requestMessage.Headers.Add("X-ARR-ClientCert", certificate.GetRawCertDataString());
    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
    var response = await client.SendAsync(requestMessage);
    
    if (response.IsSuccessStatusCode)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        var keyResponse = JsonConvert.DeserializeObject<KeyResponse>(responseContent);
    
        return keyResponse;
    }
