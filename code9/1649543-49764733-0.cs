     public void HandleRewardBasedVideoRewarded(object sender, Reward args)
        {
            int CoinOld = PlayerPrefs.GetInt("coin");
            CoinOld += 200;
            PlayerPrefs.SetInt("coin", CoinOld);
            GameObject.FindGameObjectWithTag("Coin").GetComponent<Text>().text = PlayerPrefs.GetInt("coin").ToString();
            GameObject.FindGameObjectWithTag("Double").GetComponent<Button>().interactable = false;
        
            Debug.Log("Pref: " + PlayerPrefs.GetInt("coin"));
        }
