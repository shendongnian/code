    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            PlayerPrefs.SetInt("numerator", numerator);
            PlayerPrefs.Save();
        }
    }
