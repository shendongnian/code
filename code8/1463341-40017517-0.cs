    public float speed;
    public Text countText;
    private Rigidbody rb;
    private int count;
    
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
    }
    
    void FixedUpdate()
    {
    
        float moveHorizonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
    
        Vector3 movement = new Vector3(moveHorizonal, 0.0f, moveVertical);
    
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            audio.Play(); //Play it
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
