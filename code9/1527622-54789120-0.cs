     _httpClient.DefaultRequestHeaders.Clear();
     _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            XDocument requestXml = JsonConvert.DeserializeXNode(message.ToString());
            HttpRequestMessage webRequest = new HttpRequestMessage()
            {
                Content = new StringContent(requestXml.Document.ToString().Replace("\r\n", string.Empty), Encoding.UTF8, "text/xml"),
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri),
            };
            webRequest.Headers.Add("CorrelationId", correlationId);
            webRequest.Headers.Add("SOAPAction", endpointSOAPAction);
