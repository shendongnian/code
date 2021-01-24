    private WWW wwwForm;
    
    // Use this for initialization
    void Start()
    {
        StartCoroutine(PostWWWMessage("Test"));
    }
    
    //private void PostWWWMessage(string JsonPostMessage) {
    public IEnumerator PostWWWMessage(string JsonPostMessage)
    {
    
        Debug.Log("Inside PostWWWMessage:");
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");
        byte[] postData = System.Text.Encoding.ASCII.GetBytes(JsonPostMessage.ToCharArray());
        string fullyQualifiedURL = "https://jsonplaceholder.typicode.com/posts";
    
        Debug.Log("Inside PostWWWMessage: Posting Message: " + JsonPostMessage);
        print("Posting start up request to: " + fullyQualifiedURL);
        print("Post Data is:                " + postData);
        print("Post Header is:              " + headers);
        wwwForm = new WWW(fullyQualifiedURL, postData, headers);
        //Wait for the request
        yield return wwwForm;
    
        string JsonReturnMessage;
        //Check for error
        if (String.IsNullOrEmpty(wwwForm.error))
        {
            //No Error. Access result
            JsonReturnMessage = wwwForm.text;
            Debug.Log("Received: " + JsonReturnMessage);
        }
        else
        {
            //Error while making a request
            Debug.Log(wwwForm.error);
        }
    }
