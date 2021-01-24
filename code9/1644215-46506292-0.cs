    public class SampleScript : MonoBehaviour
    {
        public Transform anchorPos;
        public GameObject detectionLineObject; // a gameObject with a line renderer
        
        private RaycastHit _hitInfo;
        private LineRenderer _detectionLine;
    
        void Start()
        {
            GameObject line = Instantiate(detectionLineObject);
            _detectionLine = line.GetComponent<LineRenderer>();
        }
    
        void Update()
        {
            DetectionManager();
        }
    
        void DetectionManager()
        {
            // check if controller is actually connected
            if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) || !OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            {
                return;
            }
            // launch a ray from the OVRCameraRig's Anchor Right
            if (Physics.Raycast(anchorPos.position, anchorPos.forward, out _hitInfo))
            {
                // set our line points
                _detectionLine.SetPosition(0, anchorPos.position);
                _detectionLine.SetPosition(1, _hitInfo.point);
    
                MyComponent target = _hitInfo.collider.gameObject.GetComponent<MyComponent>();
    
                if (target != null)
                {
                    // Do you stuff here
                    target.StartInteraction();
                }
            }
            else
            {
    
                // point our line to infinity
                _detectionLine.SetPosition(0, anchorPos.position);
                _detectionLine.SetPosition(1, anchorPos.forward * 500.0f);
            }
        }
    }
