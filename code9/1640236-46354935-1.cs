    public override void OnException(ExceptionContext context)
    {
        var le = SysMgr.Logger.NewEntry();
        try
        {
            le.Message = context.Exception.Message;
            le.AddException(context.Exception);
            var exception = context.Exception;
            var exeptionType = exception.GetType();
            var errorHandlerData = MyDictionary.ContainsKey(exceptionType) ?
                MyDictionary[exceptionType] : MyDictionary[typeof(Exception)];
            le.Type = errorHandlerData.LogType;
            context.Result = new NotFoundObjectResult(new Error(errorHandlerData.ExceptionCode, exception.Message));
            le.AddProperty("context.Result", context.Result);
        }
        finally
        {
            Task.Run(() => SysMgr.Logger.LogAsync(le)).Wait();
        }
    }
