    private ParticleSystem ps;
    public Slider slider;
    
    // Use this for initialization
    void Start()
    {
        //Cache the Slider and the ParticleSystem variables
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
    }
    
    void OnEnable()
    {
        //Subscribe to the Slider Click event
        slider.onValueChanged.AddListener(delegate { sliderCallBack(slider.value); });
    }
    
    //Will be called when Slider changes
    void sliderCallBack(float value)
    {
        Debug.Log("Slider Changed: " + value);
    
        var main = ps.main;
        main.gravityModifier = value;
    }
    
    void OnDisable()
    {
        //Un-Subscribe To Slider Event
        slider.onValueChanged.RemoveAllListeners();
    }
