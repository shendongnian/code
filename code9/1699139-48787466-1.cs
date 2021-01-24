    public class ShackUp : MonoBehaviour 
    {
        public Text scoreText;
        private int ScoreCount 
        {
            get{ return PlayerPrefs.GetInt("Score", 0); }
            set{ PlayerPrefs.SetInt("Score", value); }
        }
        private void OnDestroy()
        {
            PlayerPrefs.Save();
        }
        private void Update () 
        {
            if (Input.GetKeyDown (KeyCode.Escape))
                OnbackButtonPressed ();
            if (gameOver)
                return;
            if (Input.GetMouseButtonDown (0)) 
            {
                if (PT ())
                {               
                    SpawnTile ();
                    ScoreCount++;
                    scoreText.text = ScoreCount.ToString ();
                }
                else
                {
                    EndGame ();
                }
            }
        }
    }
