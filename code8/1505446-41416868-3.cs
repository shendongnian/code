    public class CursorTest: MonoBehaviour
    {
        void Start()
        {
            AdvanceCursor.lockState = CursorLockMode.Locked;
            AdvanceCursor.visible = true;
            //AdvanceCursor.SetCursor(...);
        }
    
        //Subscribe to Events
        void OnEnable()
        {
            AdvanceCursor.OnLockStateChanged += OnCursorLockStateChanged;
            AdvanceCursor.OnVisibleChanged += OnCursorVisibleChanged;
            AdvanceCursor.OnTextureChanged += OnCursorTextureChange;
        }
    
        //Un-Subscribe to Events
        void OnDisable()
        {
            AdvanceCursor.OnLockStateChanged -= OnCursorLockStateChanged;
            AdvanceCursor.OnVisibleChanged -= OnCursorVisibleChanged;
            AdvanceCursor.OnTextureChanged -= OnCursorTextureChange;
        }
    
        void OnCursorLockStateChanged(CursorLockMode lockMode)
        {
            Debug.Log("Cursor State changed to: " + lockMode.ToString());
        }
    
        void OnCursorVisibleChanged(bool visible)
        {
            Debug.Log("Cursor Visibility is now: " + visible);
        }
    
        void OnCursorTextureChange(Texture2D texture, Vector2 hotspot, CursorMode cursorMode)
        {
            Debug.Log("Cursor Texture Changed!");
        }
    }
