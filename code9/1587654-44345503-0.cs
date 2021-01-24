    [ServiceContract]
    public interface IService {
        [OperationContract]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped, 
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "insert/{username}/{userpassword}/{usermobile}")]
        InsertResponse Insert(string username, string userpassword, string usermobile);
    }
