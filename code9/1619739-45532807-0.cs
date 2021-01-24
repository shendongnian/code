    private TrailRenderer trail;
    public float depth;
    void Start()
    {
        depth = 10;
        trail = GetComponent<TrailRenderer>();
    }       
    void Update()
    {
        if (Input.GetMouseButton(0))
        {                      
            Vector3 mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth);
            Vector3 position = Camera.main.ScreenToWorldPoint(mousepos);
            trail.transform.position = position;
        }
    }
