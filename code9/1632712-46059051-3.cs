    using System.IO;
    
    public Text highScoreText;
       
    void Start() {
        highScoreText.text = File.ReadAllText(TEXTFILEPATH);
    }
    if (collision.tag != currentColor) {
        Debug.Log ("You Died");
        
        if (File.Exists(TEXTFILEPATH) {
            int highScore = int.TryParse(File.ReadAllText(TEXTFILEPATH);
            if(score > highScore) {
                File.WriteAllText(TEXTFILEPATH, score.ToString());
            }
        else {
            File.WriteAllText(TEXTFILEPATH, score.ToString());
        }
        }
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    score = 0;
    }
