    if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
    {
        Debug.Log("First Time Opening");
    
        //Set first time opening to false
        PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
    
        //USE TextAsset to load data
        TextAsset txtAsset = (TextAsset)Resources.Load("player", typeof(TextAsset));
        string tileFile = txtAsset.text;
        PlayerInfo pInfo = JsonUtility.FromJson<PlayerInfo>(tileFile);
    }
    else
    {
        Debug.Log("NOT First Time Opening");
    
        //USE DataHandler to load data
        PlayerInfo pInfo = DataHandler.loadData<PlayerInfo>("player");
    }
