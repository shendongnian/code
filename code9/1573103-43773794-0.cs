    public class InputController : MonoBehaviour
    {
        public event Action OnSingleTapHandler;
        public event Action OnDoubleTapHandler;
        [Tooltip("Defines the maximum time between two taps to make it double tap")]
        [SerializeField]private float tapThreshold = 0.25f;
        private Action updateDelegate;
        private float tapTimer = 0.0f;
        private bool tap = false;
     
        private void Awake()
        {
    #if UNITY_EDITOR || UNITY_STANDALONE
            updateDelegate = UpdateEditor;
    #elif UNITY_IOS || UNITY_ANDROID
            updateDelegate = UpdateMobile;
    #endif
        }
        private void Update()
        {
            if(updateDelegate != null){ updateDelegate();}
        }
        private void OnDestroy()
        {
            OnSingleTap = null;
            OnDoubleTap = null;
        }
    #if UNITY_EDITOR || UNITY_STANDALONE
        private void UpdateEditor()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time < this.tapTimer + this.tapThreshold)
                {
                    if(OnDoubleTap != null){ OnDoubleTap(); }
                    this.tap = false;
                    return;
                }
                this.tap = true;
                this.tapTimer = Time.time;
            }
            if (this.tap == true && Time.time>this.tapTimer + this.tapThreshold)
            {
                 this.tap = false;
                 if(OnSingleTap != null){ OnSingleTap();}
        }
        }
    #elif UNITY_IOS || UNITY_ANDROID
        private void UpdateMobile ()
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if(Input.GetTouch(i).tapCount == 2)
                    {
                        if(OnDoubleTap != null){ OnDoubleTap();}
                    }
                    if(Input.GetTouch(i).tapCount == 1)
                    {
                        if(OnSingleTap != null) { OnSingleTap(); }
                    }
                }
            }
        }
    #endif
    }
