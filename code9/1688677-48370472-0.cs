    // sets a number of coins into PlayerPrefs if the current coin count is greater
    public void SetCoinCount()
    {
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            int oldCoins = PlayerPrefs.GetInt("TotalCoins"); 
            if (currentCoinCount > oldCoins)
            {
                PlayerPrefs.SetInt("TotalCoins", currentCoinCount);
            }
        }
    }
