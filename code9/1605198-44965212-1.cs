    public class spin : MonoBehaviour
    {
        [SerializeField]
        private float speed = 500f;
        [SerializeField]
        private Button starter;
        [SerializeField]
        private Button stopper;
        [SerializeField]
        bool isSpinning = false;
    
        void Update()
        {    
            if (Input.GetKeyDown(KeyCode.Z))
            {
                isSpinning = true ;
            }
    
            if (Input.GetKeyDown(KeyCode.X))
            {
                isSpinning = false ;
            }
    
            if( isSpinning )
            {
                 transform.Rotate(Vector3.up, speed * Time.deltaTime)
            }
        }
    }
