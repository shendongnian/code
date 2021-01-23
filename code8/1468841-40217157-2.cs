    public class Test : MonoBehaviour
    {
        public MyWindow myWindow;
        public void OnEnable()
        {
            if (myWindow == null)
                myWindow = Object.FindObjectOfType<MyWindow>();
    
            if (myWindow == null)
                myWindow = ScriptableObject.CreateInstance<MyWindow>();
        }
    }
