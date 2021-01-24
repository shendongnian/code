    public class TestSpin : MonoBehaviour
    {
        public float speed = 500f;
        public Button starter;
        public Button stopper;
    
        bool IsRotating = false;
    
        void Start()
        {
    
            Button btn = starter.GetComponent<Button>();
            Button butn = stopper.GetComponent<Button>();
    
            butn.onClick.AddListener(FidgetSpinnerStop);
            btn.onClick.AddListener(FidgetSpinnerStart);
        }
    
        void FidgetSpinnerStart()
        {
            IsRotating = true;
        }
    
        void FidgetSpinnerStop()
        {
            IsRotating = false;
        }
    
        void Update()
        {
            if (IsRotating)
                transform.Rotate(0, speed, 0);
        }
    }
