    void OnEnable()
    {
        //Subscribe to the Slider Click event
        SliderDetector.OnClicked += OnSliderClicked;
        //Subscribe to the Slider Value Changed event
        SliderDetector.onValueChanged += OnSliderValueChanged;
    }
    //Will be called when there is a click on that slider
    private void OnSliderClicked()
    {
        //Slider Clicked Start your coroutine function
        StartCoroutine(doInOrder());
    }
    //Will be called when the slider value changes
    private void OnSliderValueChanged(float value)
    {
        //Slider Value Changed, Do Something
    }
    void OnDisable()
    {
        //Un-Subscribe to the Slider Click event
        SliderDetector.OnClicked -= OnSliderClicked;
        //Un-Subscribe to the Slider Value Changed event
        SliderDetector.onValueChanged -= OnSliderValueChanged;
    }
