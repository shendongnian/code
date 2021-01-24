    public class ScriptB : MonoBehaviour
    {
        //Other Script
        private ScriptA scriptA;
        void Start()
        {
            GameObject obj = GameObject.Find("ObjectScriptAIsAttachedTo");
            scriptA = obj.GetComponent<ScriptA>();
        }
    
        public void GetUserData()
        {
            Debug.Log("Message 1: " + scriptA.input[0].text + "Message 2: " + scriptA.input[1].text
                + " Message 3: " + scriptA.input[2].text + "Message 4: " + scriptA.input[3].text);
        }
    }
