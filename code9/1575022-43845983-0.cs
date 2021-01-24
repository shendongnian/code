    [OperationContract]
    [WebInvoke(Method = "POST",
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "ChangePassword")]
    LoginInformations ChangePassword(LoginInformations loginInformations);
    [DataContract]
    public class LoginInformations
    {
        [DataMember]
        public string UserName { set; get; }
        [DataMember]
        public string Password { set; get; }
    }
