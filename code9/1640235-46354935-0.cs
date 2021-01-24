    public class ErrorHandlerData
    {
        public LogType LogType { get; set; }
        public string ExceptionCode { get; set; } // not sure if string
    }
    public class CustomExceptionFilterAttribute :ExceptionFilterAttribute
    {
        private static Dictionary<Type, ErrorHandlerData> MyDictionary = new Dictionary<Type, ErrorHandlerData>();
        static CustomExceptionFilterAttribute()
        {
            MyDictionary.Add(typeof(NotFoundInDatabaseException), new ErrorHandlerData 
                {
                    LogType = LogType.ClientFaultMinor,
                    ExceptionCode = ExceptionCode.ResourceNotFound
                };
                //general catch-all
            MyDictionary.Add(typeof(Exception), new ErrorHandlerData 
                {
                    LogType = LogType.ErrorSevere,
                    ExceptionCode = ExceptionCode.Unknown
                };
        }
