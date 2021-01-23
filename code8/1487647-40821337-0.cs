    public class Pickup : MonoBehaviour
    {
    
        //Required Variables
        public GameObject pointsObject;
        public Text scoreText;
    
        private int score;
        private int scoreCount;
    
        List<GameObject> pickups = new List<GameObject>();
    
        void Start()
        {
            score = 0;
            SetScoreText();
            scoreCount = GameObject.FindGameObjectsWithTag("Pickups").Length;
        }
    
        void Update()
        {
            if (score >= scoreCount)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
    
            }
            SetScoreText();
            Debug.Log("Found " + scoreCount + " Pickup Objects!");
        }
    
        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Pickups"))
            {
                //Increment if the gameObject is [not] already in the List
                if (!pickups.Contains(col.gameObject))
                {
                    Destroy(col.gameObject);
                    score++;
                    //Now Add it to the List
                    pickups.Add(col.gameObject);
                }
            }
        }
    
        //Call this after GameOver to clear List
        void resetPickupsList()
        {
            pickups.Clear();
        }
    
        void SetScoreText()
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
