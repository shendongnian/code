    foreach (Application app in outPutResponse.Response.Applications)
    {
        ApplicationBuffer.AddRow();
        ApplicationBuffer.AppID = app.App_ID;
    }
