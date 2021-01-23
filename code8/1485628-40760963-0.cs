        public class AppleScript : MonoBehaviour
        {
            public float fallSpeed = 8.0f;
            //Variables for starting position and length until reset
            private Vector3 _startingPos;
            public float FallDistance = 5f;
    
            void Start()
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                // Save starting position
                _startingPos = transform.position;
            }
        
            void Update()
            {
                transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                // If the object has fallen longer than 
                // Starting height + FallDistance from its start position
                if (transform.position.y > _startingPos.y + FallDistance) {
                    transform.position = _startingPos;
                }
            }
        }
