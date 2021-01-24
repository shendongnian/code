    public class HideFlagsSetter : MonoBehaviour
    {
        public Component target;
        public HideFlags customHideFlags;
    
        public enum Mode
        {
            GameObject,
            Component
        }
    
        public Mode setOn = Mode.GameObject;
    
        [ContextMenu("Set Flags")]
        private void SetFlags()
        {
            if (setOn == Mode.GameObject)
            {
                target.gameObject.hideFlags = customHideFlags;
            }
            else if (setOn == Mode.Component)
            {
                target.hideFlags = customHideFlags;
            }
        }
    }
