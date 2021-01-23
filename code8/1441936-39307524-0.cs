    public void save()
    {
        //initialize and give some data
        SaveData data = new SaveData(autoMove, hideControls, playMusic, joystickSize);
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("playerData", jsonData);
    }
    
    public void load()
    {
        string jsonData = PlayerPrefs.GetString("playerData");
        SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
    
        //get data here
        autoMove = data.autoMove;
        hideControls = data.hideControls;
        playMusic = data.playMusic;
        joystickSize = data.joystickSize;
    }
