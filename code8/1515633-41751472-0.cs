    public class CodeText : Text
    {
        public CodeText() { 
        }
    
        void Awake() {
            Game.Instance.trackMe();
        }
    }
