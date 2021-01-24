    public class ScriptB : MonoBehaviour
    {
        //Other Script
        private InputField[] inputFields;
        void Start()
        {
            GameObject obj = GameObject.Find("");
            inputFields = obj.GetComponent<ScriptA>().input;
        }
        public void GetUserData()
        {
            Debug.Log("Message 1: " + inputFields[0].text + "Message 2: " + inputFields[1].text
                + " Message 3: " + inputFields[2].text + "Message 4: " + inputFields[3].text);
        }
    }
