    public class WinBox : MonoBehaviour
    {
        GameObject green;
        void Start()
        {
            green = GameObject.Find("Green");
        }
    
        private void OnTriggerEnter(Collider other)
        {
            green.SendMessage("finish");
        }
    }
