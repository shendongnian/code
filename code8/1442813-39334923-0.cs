    private float _startTime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = "Count: " + count.ToString ();
        winText.text = "";
        restartText.text = "";   
        _startTime = Time.time; //Save the time the game has been running.
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
    
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jump = new Vector3(0.0f, 250.0f, 0.0f);
    
            rb.AddForce(jump);
        }
    
        if (restart)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    
    
    void Update()
    {
        if (count < 14)
        {
            minutes = (int)((Time.time - _startTime) / 60f); //Subtract the time from the total time.
            seconds = (int)((Time.time - _startTime) % 60f);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }
