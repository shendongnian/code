    public class ScriptB : MonoBehaviour
    {
        public InputField[] input;
    
        public void GetUserData()
        {
            Debug.Log("Message 1: " + input[0].text + "Message 2: " + input[1].text
                + " Message 3: " + input[2].text + "Message 4: " + input[3].text);
        }
    }
