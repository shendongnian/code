        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "register?serverCode={serverCode}")]
        string Registration(string strVal);
        public string Registration(string strVal)
        {
            return "";
        }
