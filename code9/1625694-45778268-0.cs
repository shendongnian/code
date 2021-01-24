    public class Hover : MonoBehaviour
    {
        public Transform objectToMove;
        public float maxSpeed = 10f;
        public float angleSpeed = 5f;
        public float groundDistOffset = 2f;
        private Vector3 toUpPos = Vector3.zero;
    
        void Update()
        {
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
    
            Vector3 objPos = objectToMove.position;
            objPos += objectToMove.forward * vInput * maxSpeed * Time.deltaTime;
            objPos += objectToMove.right * hInput * maxSpeed * Time.deltaTime;
    
            RaycastHit hit;
    
            if (Physics.Raycast(objectToMove.position, -Vector3.up, out hit))
            {
                //Get y position
                objPos.y = (hit.point + Vector3.up * groundDistOffset).y;
    
                //Get rotation
                toUpPos = hit.normal;
            }
    
            //Assign position of the Object
            objectToMove.position = objPos;
    
            //Assign rotation/axis of the Object
            objectToMove.up = Vector3.Slerp(objectToMove.up, toUpPos, angleSpeed * Time.deltaTime);
        }
    }
