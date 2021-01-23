    using (OperationContextScope scope = new OperationContextScope(orderNumberClient.InnerChannel))
    {
        var httpRequestProperty = new HttpRequestMessageProperty();
        httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " +
        Convert.ToBase64String(Encoding.ASCII.GetBytes(orderNumberClient.ClientCredentials.UserName.UserName + ":" +
        orderNumberClient.ClientCredentials.UserName.Password));
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
        string Response = orderNumberClient.getNewOrderNumber(IDSystem, "01", IDOSystem);
    }
 
