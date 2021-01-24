    public float playerSpeed = 10f;
    public GameControl gameController;
    public GameObject bulletPrefab;
    public float reloadTime = 1f;
    
    private float elapsedTime = 0;
    
    private bool dragging = false;
    
    
    void Update()
    {
    
        if (Input.touchCount >= 1)
        {
            foreach (Touch touch in Input.touches) 
            {
                Ray ray = Camera.main.ScreenPointToRay (touch.position);
                RaycastHit hit;
                
                if (Physics.Raycast (ray, out hit, 100)) 
                {
                    if(hit.collider.tag == "Player") // check if hit collider has Player tag
                    {
                        dragging = true;
                    }
                }
                
                if(dragging)
                {
                    //First rotate the player towards the touch (should do some checks if it's not too close so it doesn't glitch out)
                    Vector3 _dir = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                    _dir.Normalize();
             
                    float _rotZ = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0f, 0f, _rotZ - 90);
                    
                    //Move towards the touch
                    transform.GetComponent<Rigidbody>().AddRelativeForce(direction.normalized * playerSpeed, ForceMode.Force);
                }
            }
        }
    }
    
