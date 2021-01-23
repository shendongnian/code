    public class GuiController : MonoBehaviour
    {
        //singleton setup
        static GuiController instance;
        void Awake() { instance = this; }
    
        //now it's ready for static calls
    
        public UnityEngine.UI.Text MyText;
    
        //static call
        public static void SetMyText(string txt) { instance.MyText.text = txt; }
    }
