    UncaughtExceptionHandlers.Add((req, res, operationName, ex) =>
    {
        res.ContentType = MimeTypes.Xml;
        res.Write($@"<?xml version=""1.0"" encoding=""utf-8"" ?>
            <Response>
                <actionCode>{ex.Message}</actionCode>
                <errorCode>{ex.GetType().Name}</errorCode>
            </Response>");
        res.EndRequest();
    });
