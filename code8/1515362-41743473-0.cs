    public class CamMovement : MonoBehaviour
    {
        //using "parent" as variable name is not recommended since Transform class already contains a parent variable
        [SerializeField]
        private GameObject parentToLookAt;
        [SerializeField]
        private Vector3 localPositionOffset;
        [Range(0.0f, 10.0f)]
        [SerializeField]
        private float transitionSpeed;
        private Vector3 localPositionOnStart;
        private bool applyOffset;
        void Start()
        {
            localPositionOnStart = transform.localPosition;
            applyOffset = false;
        }
        void Update()
        {
            //Makes sure the camera always looks at the player object
            //You can also use: transform.LookAt(transform.parent); 
            transform.LookAt(parentToLookAt.transform);
            //Moves the camera to the right local position (note that using Mathf.Lerp is not optimal performance-wise but if you want more info on this
            //I recommend looking for further informations at https://chicounity3d.wordpress.com/2014/05/23/how-to-lerp-like-a-pro/ )
            if (applyOffset)
            {
                transform.localPosition = Mathf.Lerp(transform.localPosition, localPositionOnStart + localPositionOffset, transitionSpeed * Time.deltaTime);
            }
            else
            {
                transform.localPosition = Mathf.Lerp(transform.localPosition, localPositionOnStart, transitionSpeed * Time.deltaTime);
            }
        }
        //Checks if the camera collides with something
        void OnTriggerEnter(Collider other)
        {
            applyOffset = true;
        }
        //Checks if the camera stops colliding with something
        void OnTriggerExit(Collider other)
        {
            applyOffset = false;
        }
        //You can also use this:
        //void OnTriggerStay(Collider other)
        //{
        //    applyOffset = true;
        //}
        // and set applyOffset to false at the end of the Update() method (OnTrigger events are called before Update each frame)
    }
