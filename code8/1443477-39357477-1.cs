     var client = new WCClient();  
     using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
     {
         var httpRequestProperty = new HttpRequestMessageProperty();
         httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " +
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(client.ClientCredentials.UserName.UserName + ":" +
                      client.ClientCredentials.UserName.Password));
         OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
         client.DoSomething();
     }
