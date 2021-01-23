    public class SliderDetector : MonoBehaviour, IPointerClickHandler
    {
        public Slider slider;
    
        public delegate void sliderClicked();
        public static event sliderClicked OnClicked;
    
        public delegate void valueChanged(float value);
        public static event valueChanged onValueChanged;
    
        // Use this for initialization
        void Awake()
        {
            slider = GetComponent<Slider>();
            //Subscribe To Slider Event
            slider.onValueChanged.AddListener(delegate { sliderCallBack(slider.value); });
        }
    
    
        public void OnPointerClick(PointerEventData eventData)
        {
            if (OnClicked != null)
            {
                //Notify All Subscribed function
                OnClicked();
            }
        }
    
        void sliderCallBack(float value)
        {
            if (onValueChanged != null)
            {
                //Notify All Subscribed function
                onValueChanged(value);
            }
        }
    
        void OnDisable()
        {
            //Un-Subscribe To Slider Event
            slider.onValueChanged.RemoveListener(delegate { sliderCallBack(slider.value); });
        }
    }
