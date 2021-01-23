    using UnityEngine;
    
    public class ToastText3D : MonoBehaviour
    {
        public static ToastText3D Instance { get; private set; }
    
        private static bool isShowingTextMessage;
        private static GameObject textMeshGameObject;
    
        // Preventing instantiation of class by making constructor protoected (or private)
        protected ToastText3D() { }
    
        private void Awake()
        {
            // Check if instance already exists
            if (Instance == null)
                // if not, set instance to this
                Instance = this;
            else if (Instance != this)
                // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
    
            // Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }
    
        private void Update()
        {
            if (!isShowingTextMessage)
                return;
    
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;
    
            float distanceFromCamera = 2; // TODO: Move this to const
    
            Vector3 desiredPosition = headPosition + gazeDirection * distanceFromCamera;
            textMeshGameObject.transform.position = desiredPosition;
    
            // Rotate the object to face the user.
            Quaternion toQuat = Camera.main.transform.localRotation;
            toQuat.x = 0;
            toQuat.z = 0;
            textMeshGameObject.transform.rotation = toQuat;
        }
        
        // Returns current text mesh or creates new one if there is no
        private TextMesh getCurrentTextMesh()
        {
            if (!textMeshGameObject)
                textMeshGameObject = new GameObject();
    
            TextMesh curTextMesh = textMeshGameObject.GetComponent(typeof(TextMesh)) as TextMesh;
            if (!curTextMesh)
            {
                // TODO: Make constants
                curTextMesh = textMeshGameObject.AddComponent(typeof(TextMesh)) as TextMesh;
                MeshRenderer meshRenderer = textMeshGameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
                meshRenderer.enabled = true;
                curTextMesh.anchor = TextAnchor.MiddleCenter;
                curTextMesh.alignment = TextAlignment.Center;
                curTextMesh.fontStyle = FontStyle.Bold;
                curTextMesh.fontSize = 20;
    
                curTextMesh.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            }
    
            return curTextMesh;
        }
    
        public void Show3DTextToast(string textToShow, int timeout = 5)
        {
            if (timeout < 0 || textToShow == "")
                return;
            
            TextMesh curTextMesh = getCurrentTextMesh();
    
            curTextMesh.text = textToShow;
    
            textMeshGameObject.SetActive(true);
            isShowingTextMessage = true;
            
            // Canceling message hiding invokation if there was any
            CancelInvoke("Hide3DTextToast"); // TODO: Move function name to const
            // Hiding text if there is any timeout
            if (timeout != 0)
                Invoke("Hide3DTextToast", timeout);
        }
    
        public void Hide3DTextToast()
        {
            textMeshGameObject.SetActive(false);
            isShowingTextMessage = false;
        }
    }
