    [ServiceContract]
    public interface IService
    {
        ...
        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        [return: MessageParameter(Name = "timeline")]
        Entity DoWork(Entity entity);
        ...
    }
