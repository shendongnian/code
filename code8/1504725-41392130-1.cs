    public class ButtonClickDetector : MonoBehaviour
    {
        public Button button1;
        public Button button2;
        public Button button3;
    
        void OnEnable()
        {
            //Register Button Events
            button1.onClick.AddListener(() => buttonCallBack(button1));
            button2.onClick.AddListener(() => buttonCallBack(button2));
            button3.onClick.AddListener(() => buttonCallBack(button3));
    
        }
    
        private void buttonCallBack(Button buttonPressed)
        {
            if (buttonPressed == button1)
            {
                //Your code for button 1
                Debug.Log("Cllicked: " + button1.name);
            }
    
            if (buttonPressed == button2)
            {
                //Your code for button 2
                Debug.Log("Cllicked: " + button2.name);
            }
    
            if (buttonPressed == button3)
            {
                //Your code for button 3
                Debug.Log("Cllicked: " + button3.name);
            }
        }
    
        void OnDisable()
        {
            //Un-Register Button Events
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button3.onClick.RemoveAllListeners();
        }
    }
