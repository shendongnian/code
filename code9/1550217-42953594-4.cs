    void LogCallback(string condition, string stackTrace, LogType type)
    {
        //Send Email
    
        System.Diagnostics.StackTrace sTrace = new System.Diagnostics.StackTrace();
        Debug.Log(sTrace.ToString());
    }
