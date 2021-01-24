    public void LoadGame(int slot)
    {
        var saveFileName = Application.persistentDataPath + "/Save_" + slot+ ".save";
        var saveFilecontent = File.ReadAllText(saveFileName);
        //please note, i have no idea if this works, because i don't know whay your
        //JsonUtility does. this is an educated guess.
        var deSerializedSave =  JsonUtility.FromJson<Saves>(saveFilecontent);
    
        saves = deSerializedSave;
    
        //you can now switch scene, set variables etc. form your "saves" object.
    
    }
