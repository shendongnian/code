     [OperationContract]
    [WebGet(UriTemplate = "Filter/{paramName}/{paramValue}"),  
     RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    string[] Filter(string paramName,string paramValue);
    
