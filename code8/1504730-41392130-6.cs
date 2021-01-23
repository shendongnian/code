    public Slider slider;
    
    void OnEnable()
    {
        //Subscribe to the Slider Click event
        slider.onValueChanged.AddListener(delegate { sliderCallBack(slider.value); });
    }
    
    //Will be called when Slider changes
    void sliderCallBack(float value)
    {
        Debug.Log("Slider Changed: " + value);
    }
    
    void OnDisable()
    {
        //Un-Subscribe To Slider Event
        slider.onValueChanged.RemoveListener(delegate { sliderCallBack(slider.value); });
    }
