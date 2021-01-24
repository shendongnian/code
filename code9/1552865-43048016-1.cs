    [ServiceContract]
    public interface IService1
    {
    	[OperationContract]
    	[WebGet(BodyStyle = WebMessageBodyStyle.Wrapped,
    		RequestFormat = WebMessageFormat.Xml,
    		ResponseFormat = WebMessageFormat.Xml,
    		UriTemplate = "/TestGet")]
    	string TestGet();
    }
