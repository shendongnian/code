    public Button button;
    
    void OnEnable()
    {
        button.onClick.AddListener(() => { StartCoroutine(GetFromDB()); });
    }
    
    void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
    
    IEnumerator GetFromDB()
    {
        var url = "http://historicstructures.org/action_page_post.php";
        var form = new WWWForm();
        form.AddField("Author", "Jess");
    
        WWW www = new WWW(url, form);
    
        // wait for request to complete
        yield return www;
    
        // and check for errors
        if (String.IsNullOrEmpty(www.error))
        {
            UnityEngine.Debug.Log(www.text);
        }
        else
        {
            // something wrong!
            UnityEngine.Debug.Log("WWW Error: " + www.error);
        }
    }
