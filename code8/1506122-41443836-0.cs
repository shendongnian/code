    void Start () {
        InvokeRepeating("GetData", 1.0f, 1.0f);   
    }
    void GetData()
    {
        StartCoroutine(GetDataCoroutine())    
    }
    IEnumerator GetDataCoroutine()
    {
         WWW www = new WWW(url);
         yield return www;  
         if(string.IsNullOrEmpty(www.error) == false){ Debug.Log(www.error); } 
         www.Dispose();  
    }
