    public class spawn : MonoBehaviour {
        public Transform[] SpawnPoints;
        public GameObject ball;
        public GameObject lastBall;
    
        // Use this for initialization
        void Start () {
            int SpawnIndex = Random.Range (0, SpawnPoints.Length);
            lastBall = Instantiate (ball, SpawnPoints [SpawnIndex].position, SpawnPoints [SpawnIndex].rotation) as GameObject;
        }
    
        void Update(){
            if (lastBall.position.z > -0.904 ) {
                int SpawnIndex = Random.Range (0, SpawnPoints.Length);
                lastBall = Instantiate (ball, SpawnPoints [SpawnIndex].position, SpawnPoints [SpawnIndex].rotation) as GameObject;
            }
        }
    } 
