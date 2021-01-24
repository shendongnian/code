    public GameObject deathFlamePrefab;
    private bool flamer;
    private bool pay = false;
    private bool broke = false;
    
    void Start ()
    {
        anim = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody2D> ();
    }
    
    // Update is called once per frame
    void Update ()
    {
        Looted ();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!kicked && other.gameObject.tag == "kickIndicator") {
            kicked = true;
            transform.Translate (0.0f, .05f, 0.0f);
        }
    }
    
    public void Looted ()
    {
        if (!pay && kicked) {
    
            pay = true;
            kicked = false;
            for (int i = 1; i <= 3; i++)
            {
                Instantiate (coinPrefab, coinSpawn.position, coinSpawn.rotation);
                Debug.Log ("$$$$$$$$$");
            }
            pay = false;
        }
    }
