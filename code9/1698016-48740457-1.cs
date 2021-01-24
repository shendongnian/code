    public interface IExamService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/ExamQs",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        ExamClass GetExam();
    }
