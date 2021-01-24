    class SceneController {
        GameObject muteButton;
        
        void Start() {
            muteButton = GameObject.FindWithTag("muteButton");
            muteButton.AddListener(muteButtonCheck);
        }
        void muteButtonClick() {
            if (PlayerPrefs.GetInt("playerMute")) {
                // If 1 (on)
                // Set sound off
                PlayerPref.SetInt("playerMute", 0);
            } else {
                // It's 0 (off)
                // Set sound on
                PlayerPrefs.SetInt("playerMute", 1);
            }
        }
    }
