    void saveData()
    {
        PlayerPrefs.SetInt("T55", boolToInt(T55.interactable));
        PlayerPrefs.SetInt("Tiger2", boolToInt(T55.interactable));
        PlayerPrefs.SetInt("Cobra", boolToInt(T55.interactable));
    }
    
    void loadData()
    {
        T55.interactable = intToBool(PlayerPrefs.GetInt("T55", 0));
        Tiger2.interactable = intToBool(PlayerPrefs.GetInt("Tiger2", 0));
        Cobra.interactable = intToBool(PlayerPrefs.GetInt("Cobra", 0));
    }
