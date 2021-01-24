    [DataContract(Namespace="http://yournamespace.com")]
    public class MyContract
    {
       [DataMember(Order=1)]
       public string DomainName { get(); set{};}
    
       [DataMember(Order=2)]
       public string UserID { get(); set{};}
       ...
    }
    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/RestAuthenticateUser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        authResultDTO RestAuthenticateUser(AuthRequest authRequest);
    
    public authResultDTO AuthenticateUser(MyContract contract)
    {
        ...
    }
