    public class Enemy : MonoBehaviour 
    {
        public GameObject deathEffect;
        public float health = 4f;
        public static int EnemiesAlive = 0;
        public int loadToScene;
        SceneLoader sceneLoader;
    
        void Start ()
        {
            sceneLoader = GameObject.Find("SceneLdObj").GetComponent<SceneLoader>();
            EnemiesAlive++;
        }
    
        void OnCollisionEnter2D (Collision2D colInfo)
        {
            if (colInfo.relativeVelocity.magnitude > health)
            {
                Die();
            }
        }
    
        void Die ()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            EnemiesAlive--;
    
            if (EnemiesAlive <= 0)
            {
                Debug.Log ("LEVEL WON!");
                //Call that function from another script
                sceneLoader.ChangeScene(1);
            }
            Destroy(gameObject);
        }
    
        void ChangeScene()
        {
            Debug.Log ("Hello");
            loadToScene = 1;
            SceneManager.LoadScene (loadToScene);
        }
    }
