    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "post",
     BodyStyle = WebMessageBodyStyle.Wrapped,
     ResponseFormat = WebMessageFormat.Json,
     RequestFormat = WebMessageFormat.Json)]
        bool CallDateSetup(CompositeType data);
