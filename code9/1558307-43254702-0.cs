    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
          return;
        }
    
        if(lives == 0)
        {
            SceneManager.LoadScene("Lose");
    
        }
    
    
    
        livesText.text = "Lives: " + lives;
    }
