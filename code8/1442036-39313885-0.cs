    public Slider SliderObject;
    public Text SliderFeedback;
    
    void Start()
    {
        SliderObject.onValueChanged.AddListener(delegate { SetFeedback((long)SliderObject.value); });
    }
    
    public void Function(long MaximumValue)
    {
        SliderObject.minValue = 1000;
        SliderObject.maxValue = MaximumValue;
        SetFeedback((long)SliderObject.value);
    }
    
    void SetFeedback(long value)
    {
        SliderFeedback.text = value.ToString();
    }
