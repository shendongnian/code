    public class AdvanceCursor
    {
        //Not needed but included just because Cursor has a pulbic constructor
        private Cursor cursor;
    
        public AdvanceCursor()
        {
            cursor = new Cursor();
        }
    
        public static CursorLockMode lockState
        {
            set
            {
                Cursor.lockState = value;
                //Notify Event
                if (OnLockStateChanged != null)
                {
                    OnLockStateChanged(value);
                }
            }
    
            get { return Cursor.lockState; }
        }
    
        public static bool visible
        {
            set
            {
                Cursor.visible = value;
                //Notify Event
                if (OnVisibleChanged != null)
                {
                    OnVisibleChanged(value);
                }
            }
    
            get { return Cursor.visible; }
        }
    
        public static void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode)
        {
            Cursor.SetCursor(texture, hotspot, cursorMode);
            //Notify Event
            if (OnTextureChanged != null)
            {
                OnTextureChanged(texture, hotspot, cursorMode);
            }
        }
    
        /////////////////////////////////////////////EVENTS//////////////////////////////////
    
        //Event For LockState
        public delegate void cursorLockStateAction(CursorLockMode lockMode);
        public static event cursorLockStateAction OnLockStateChanged;
    
        //Event For visible
        public delegate void cursorVisibleAction(bool visible);
        public static event cursorVisibleAction OnVisibleChanged;
    
        //Event For Texture Change
        public delegate void cursorTextureAction(Texture2D texture, Vector2 hotspot, CursorMode cursorMode);
        public static event cursorTextureAction OnTextureChanged;
    }
