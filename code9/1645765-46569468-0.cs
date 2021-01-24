    public class PlayerNodePosition : MonoBehaviour 
    {
        public static PlayerNodePosition instance;
        string code;
        void static getInstance()
        {
            if (instance == null)
            {
                instance = new PlayerNodePosition();
            }
            return instance;
        }
        public void AddCode(string _code)
        {
            code = _code;
        }
    }
