    public class FocusListener : MonoBehaviour
    {
        public static bool isFocused = true;
        void OnApplicationFocus (bool hasFocus) {
            isFocused = hasFocus;
        }
    }
