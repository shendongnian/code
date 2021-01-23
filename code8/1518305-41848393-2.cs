    public class testMove : MonoBehaviour
    {
        public Transform startObj;
        public Transform endObj;
        private Transform endObjLookAt;
    
        public float rotationDuration;
        public AnimationCurve rotationCurve;
    
        public float movementDuration;
        public AnimationCurve movementCurve;
    
        private IEnumerator moveAndRotateCameraIEnumerator;
    
        void Start()
        {
            // If you want to do it on start just call MoveAndRotateCamera() here, else call if from anywhere you want (a script, a game button, ...)
        }
    
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                MoveAndRotateCamera();
            }
        }
    
        public void MoveAndRotateCamera(Transform startTransform = null, Transform endTransform = null)
        {
            if(startTransform)
            {
                startObj = startTransform;
            }
            else
            {
                startObj = this.transform;
            }
    
            if(endTransform)
            {
                endObj = endTransform;
            }
            endObjLookAt = GameObject.Find(endObj.name + "LookAt").transform;
    
            if(moveAndRotateCameraIEnumerator != null)
            {
                StopCoroutine(moveAndRotateCameraIEnumerator);
            }
            moveAndRotateCameraIEnumerator = MoveAndRotateCameraCoroutine();
            StartCoroutine(moveAndRotateCameraIEnumerator);
        }
    
        private IEnumerator MoveAndRotateCameraCoroutine()
        {
            //ROTATION
            Vector3 startEulerAngles = transform.eulerAngles;
            transform.LookAt(endObjLookAt);
            Vector3 deltaEulerAngles = new Vector3(Mathf.DeltaAngle(startEulerAngles.x, transform.eulerAngles.x), Mathf.DeltaAngle(startEulerAngles.y, transform.eulerAngles.y), Mathf.DeltaAngle(startEulerAngles.z, transform.eulerAngles.z));
    
            Debug.Log("Starting rotation...");
            float timer = 0.0f;
            while(timer < rotationDuration)
            {
                timer += Time.deltaTime;
                transform.eulerAngles = startEulerAngles + deltaEulerAngles * rotationCurve.Evaluate(timer / rotationDuration);
                yield return new WaitForEndOfFrame();
            }
            transform.eulerAngles = startEulerAngles + deltaEulerAngles;
            Debug.Log("Rotation done!");
            //----
    
            //MOVEMENT
            Vector3 startPosition = transform.position;
    
            Debug.Log("Starting movement...");
            timer = 0.0f;
            while(timer < movementDuration)
            {
                timer += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endObj.position, movementCurve.Evaluate(timer / movementDuration));
                transform.LookAt(endObjLookAt);
                yield return new WaitForEndOfFrame();
            }
            transform.position = endObj.position;
            transform.LookAt(endObjLookAt);
            Debug.Log("Movement done!");
            //----
        }
    }
