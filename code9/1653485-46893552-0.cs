    //container for cursor data
    [System.Serializable]
    public struct CustomCursor
    {
        public Texture2D Texture;
        public Vector2 HotSpot;
        public CursorMode Mode;
    }
    //container for all cursor you used in you project
    [System.Serializable]
    public class CursorsHolder
    {
        [SerializeField]
        private CustomCursor defaultCursor;
        [SerializeField]
        private CustomCursor cursorA;
        [SerializeField]
        private CustomCursor cursorB;
        [SerializeField]
        private CustomCursor cursorC;
        public CustomCursor DefaultCursor { get { return defaultCursor; } }
        public CustomCursor CursorA { get { return cursorA; } }
        public CustomCursor CursorB { get { return cursorB; } }
        public CustomCursor CursorC { get { return cursorC; } }
        public void InitializeDefault(CustomCursor defaultCursor)
        {
            this.defaultCursor = defaultCursor;
        }
    }
    public interface ICursorHandler
    {
        Texture2D CurrentCursor { get; }
        void SetCursor(CustomCursor newCursor);
    }
    //Manager that cached last setted cursor
    public class CursorHandler
    {
        private CustomCursor currentCursor;
        public CustomCursor CurrentCursor { get { return currentCursor; } }
        public void SetCursor(CustomCursor newCursor)
        {
            currentCursor = newCursor;
            Cursor.SetCursor(currentCursor.Texture, currentCursor.HotSpot, currentCursor.Mode);
            Debug.LogFormat("{0}", currentCursor.Texture);
        }
    }
    //Main script for cursor management usage
    public class MyScript : MonoBehaviour
    {
        [SerializeField]
        private CursorsHolder cursorsData;
        ICursorHandler cursorHandler = new CursorHandler();
        private void Awake()
        {
            cursorsData.InitializeDefault(new CustomCursor() { Texture = PlayerSettings.defaultCursor, HotSpot = Vector2.zero, Mode = CursorMode.ForceSoftware });
            cursorHandler.SetCursor(cursorsData.DefaultCursor);     
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                cursorHandler.SetCursor(cursorsData.CursorA);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                cursorHandler.SetCursor(cursorsData.CursorB);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                cursorHandler.SetCursor(cursorsData.CursorC);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                cursorHandler.SetCursor(cursorsData.DefaultCursor);
            }
        
        }
    }
