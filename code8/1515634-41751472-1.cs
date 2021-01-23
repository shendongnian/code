    public class CodeText : Text
    {
        public CodeText() : base() { 
        }
    
        void Awake() {
            Game.Instance.trackMe();
        }
    }
