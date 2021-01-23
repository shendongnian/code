    using(var client = new SoapService.ServiceClient()){
       using(new OperationContextScope((IClientChannel)client.InnerChannel)){
           WebOperationContext.Current.OutgoingRequest.Headers.Add("Authorization", 
               Convert.ToBase64String(Encoding.Default.GetBytes(String.Format("{username}:{password}", Username, Password))));
           // Call/Invoke service here
       }
    }
