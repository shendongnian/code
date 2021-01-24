    [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/CallResult/{username}/{company}")]
        CallResult_Result[] CallResult(string username, string company);
