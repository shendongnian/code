    void Start()
    {
        StartCoroutine(putRequest("http:///www.yoururl.com"));
    }
    
    IEnumerator PutRequest(string url)
    {
        byte[] dataToPut = System.Text.Encoding.UTF8.GetBytes("Hello, This is a test");
        UnityWebRequest uwr = UnityWebRequest.Put(url, dataToPut);
        yield return uwr.SendWebRequest();
    
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
