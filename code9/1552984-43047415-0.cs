    public GameObject Enemy;
    public GameObject Bullet;
    public float bulletForce = 100f;
    
    private Vector3 direction;
    
    // Use this for initialization
    void Start ()
    {
        ShootFunctionRepeat();  
    }
    
    // Update is called once per frame
    void Update ()
    {
        direction = (Enemy.transform.position - this.transform.position).normalized;    
    }
    
    void ShootFunctionRepeat()
    {
        InvokeRepeating("ShootFunction", 0.0f, 1.0f);
    }
    
    void ShootFunction()
    {
        GameObject temp = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletForce);
    }
