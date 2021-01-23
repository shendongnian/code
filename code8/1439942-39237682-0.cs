    public class Spawner1 : MonoBehaviour {
    
        public GameObject[] group;
        void Start(){
            SpawnNext ();
        }
    
        void SpawnNext(){
            Instantiate(group[Random.Range(0,group.Length)],new Vector2(5.0f,10.0f),Quaternion.identity);
        }
    }
