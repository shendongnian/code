    public static void AppRequest(
        string message, 
        OGActionType actionType,
        string objectId,
        IEnumerable<string> to,
        string data = "",
        string title = "",    
        FacebookDelegate<IAppRequestResult> callback = null
    )
