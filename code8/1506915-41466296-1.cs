    public class MoveVertically
        : MonoBehaviour 
    {
        public void Move (float speed) 
        {
            transform.Translate (speed);
        }
    }
    
    // Controller
    public class MoveChildrenVertically 
        : MonoBehaviour 
    {
        public float Speed;
    
        MoveVertically[] children;
    
        void Start()
        {
            children = GetComponentsInChildren<MoveVertically> ();
        }
    
        void Update()
        {
            Speed = ChangeSpeed(); // if needed
            float speed = Vector3.down * Time.deltaTime * Speed;
            foreach (var child in children) 
            {
                child.Move(speed);
            }
        }
    }
