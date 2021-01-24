    public class spin : MonoBehaviour
    {
        public float speed = 500f;
        public Button starter;
        public Button stopper;
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
