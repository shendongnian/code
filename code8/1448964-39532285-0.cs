    namespace API
    {
        [ServiceContract]
        public interface IDiamond
        {
            [OperationContract]
            [WebInvoke(Method = "GET",
                        ResponseFormat = WebMessageFormat.Json,
                        BodyStyle = WebMessageBodyStyle.Bare,
                        UriTemplate = "category")]
            List<Category> SelectCategory();
        }
    }
    
