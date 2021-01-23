    public class ButtonTest : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            //Register to Button events
            ButtonDownRelease.OnButtonActionChanged += ButtonActionChange;
            Debug.Log("Registered!");
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        //Un-Register to Button events
        void OnDisable()
        {
            ButtonDownRelease.OnButtonActionChanged -= ButtonActionChange;
        }
    
    
        //Will be called when there is a Button action
        void ButtonActionChange(ButtonAction buttonAction)
        {
            //Check for held down
            if (buttonAction == ButtonAction.DecreaseButtonDown)
            {
                Debug.Log("Decrease Button held Down!");
                DecreaseBPM();
            }
    
            if (buttonAction == ButtonAction.IncreaseButtonDown)
            {
                Debug.Log("Increase Button held Down!");
                IncreaseBPM();
            }
    
            //Check for release
            if (buttonAction == ButtonAction.DecreaseButtonUp)
            {
                Debug.Log("Decrease Button Released!");
            }
    
            if (buttonAction == ButtonAction.IncreaseButtonUp)
            {
                Debug.Log("Increase Button Released!");
            }
        }
    
        private void IncreaseBPM()
        {
            if (TempoController.GetComponent<Pendulum>().speed < 12)
            {
                TempoController.GetComponent<Pendulum>().speed += 0.05f;
            }
        }
    
        private void DecreaseBPM()
        {
            if (TempoController.GetComponent<Pendulum>().speed > 1.5)
            {
                TempoController.GetComponent<Pendulum>().speed -= 0.05f;
            }
        }
    }
