    public class Move : MonoBehaviour
    {
        public GameObject boxLid1;
        public float speed = 5.0f;
    
        public void Update() 
        {
            BlueBox.transform.position = Vector3.MoveTowards(
                BlueBox.transform.position, boxLid1.transform.position,
                Time.deltaTime * speed);
        }
    }
