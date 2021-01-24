    void Start()
    {
        StartCoroutine(deleteRequest("http:///www.yoururl.com"));
    }
    
    IEnumerator DeleteRequest(string url)
    {
        UnityWebRequest uwr = UnityWebRequest.Delete(url);
        yield return uwr.SendWebRequest();
    
        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Deleted");
        }
    }
