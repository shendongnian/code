    // Assign client.ClientCredentials.UserName.UserName and client.ClientCredentials.UserName.Password 
    SetupClientAuthentication(); 
    
    HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty(); 
    
    httpRequestProperty.Headers[HttpRequestHeader.Authorization] = "Basic " + 
        Convert.ToBase64String(Encoding.ASCII.GetBytes(client.ClientCredentials.UserName.UserName + ":" + 
        client.ClientCredentials.UserName.Password));
    
    using (OperationContextScope scope = new OperationContextScope(client.InnerChannel)) 
    { 
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = 
            httpRequestProperty;
    
        // Invoke client 
    }
