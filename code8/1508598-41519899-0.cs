    public static void Get(Action<int> callback)
    {
        if (time == null)
        {
            Debug.Log("Script not attached to anything");
            GameObject obj = new GameObject("TimeHolder");
            localInstance = obj.AddComponent<ServerTime>();
            Debug.Log("Automatically Attached Script to a GameObject");
        }
        time.StartCoroutine(time.ServerRequest(callback));
    }
    IEnumerator ServerRequest(Action<int> callback)
    {
        WWW www = new WWW("http://www.businesssecret.com/something/servertime.php");
        yield return www;
        if (www.error == null)
        {
            int _timestamp = int.Parse(www.text);
            // somehow return _timestamp
            callback(_timestamp);
            Debug.Log(_timestamp);
        }
        else
        {
            Debug.LogError("Oops, something went wrong while trying to receive data from the server, exiting with the following ERROR: " + www.error);
        }
    }
