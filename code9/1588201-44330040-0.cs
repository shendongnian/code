    public YourClassNameHere()
    {
        callback = new ApiCallback()
         {
             onSuccess = (string response, long responseCode) => {
                 Debug.Log(response);
                 Debug.Log(responseCode + "");
                 test();
             },
             onError = (string exception) => {
                 Debug.Log(exception);
             }
         };
    }
