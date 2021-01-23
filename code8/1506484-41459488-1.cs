    public class Lose : MonoBehaviour
    {
        public GameObject Button;
        public GameObject Target;
        public GameObject loseObject;
    
    
        public int missedAmount = 0;
        public int clickedAmount = 0;
        const int MISSED_MAX_AMOUNT = 10;
    
        //public ButtonReposition script;
        public void ChangeScene(int changeTheScene)
    
        {
            SceneManager.LoadScene(changeTheScene);
        }
    
        private ButtonDetector buttonImage;
    
        void Start()
        {
            GameObject obj = GameObject.Find("ButtonImage");
            buttonImage = obj.GetComponent<ButtonDetector>();
        }
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (buttonImage.clicked)
                {
    
                    Debug.Log("Mouse Clicked on Button!");
                    clickedAmount++;
                    //Reset missedAmount to 0
                    missedAmount = 0;
                }
                else
                {
                    Debug.LogWarning("Mouse Click on SOMETHING ELSE");
                    missedAmount++;
                }
    
                if (missedAmount == 10)
                {
                    Debug.LogWarning("GameOver!");
                    Debug.LogWarning("Missed 10 times in a row!");
                    SceneManager.LoadScene(2);
                    //Destroy(buttonImage.gameObject);
                }
            }
        }
    }
