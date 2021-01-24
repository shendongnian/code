    IEnumerator getRequest(string uri, Action<bool> success)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
    
        //Check if there is an error
        if (uwr.isError || !String.IsNullOrEmpty(uwr.error))
        {
            success(false);
        }
        else
        {
            success(true);
            //Store downloaded data to the global variable
            downloadedData = uwr.downloadHandler.data;
        }
    }
