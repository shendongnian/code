    public class Test: MonoBehaviour
    {
        GameObject messageBox = null;
        Transform penaltySpawnLoc = null;
        GameObject penaltyPrefab = null;
    
        void Start()
        {
            gameObject.Instantiate(messageBox, penaltySpawnLoc.position, penaltyPrefab.transform.rotation, transform, "Hello");
        }
    }
