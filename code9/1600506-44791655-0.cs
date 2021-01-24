    public float speed = 500f;
    public Button starter;
    public Button stopper;
    bool isSpinning = false;
    
    IEnumerator spinnerCoroutine;
    
    void Start()
    {
        //The spin function
        spinnerCoroutine = spinCOR();
    
        Button btn = starter.GetComponent<Button>();
        Button butn = stopper.GetComponent<Button>();
    
        butn.onClick.AddListener(FidgetSpinnerStop);
        btn.onClick.AddListener(FidgetSpinnerStart);
    }
    
    IEnumerator spinCOR()
    {
        //Spin forever untill FidgetSpinnerStop is called 
        while (true)
        {
            transform.Rotate(Vector3.up, speed * Time.deltaTime);
            //Wait for the next frame
            yield return null;
        }
    }
    
    void FidgetSpinnerStart()
    {
        //Spin only if it is not spinning
        if (!isSpinning)
        {
            isSpinning = true;
            StartCoroutine(spinnerCoroutine);
        }
    }
    
    void FidgetSpinnerStop()
    {
        //Stop Spinning only if it is already spinning
        if (isSpinning)
        {
            StopCoroutine(spinnerCoroutine);
            isSpinning = false;
        }
    }
