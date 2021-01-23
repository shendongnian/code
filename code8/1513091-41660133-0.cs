    Camera cam;
    
    void Start()
    {
        cam = GameObject.Find("NameOfCameraGameObject").GetComponent<Camera>();
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.GetTouch(0).position), Vector2.zero);
            if (hit && hit.collider != null && hit.collider.name == "leftTapArea")
            {
                hit.transform.name = "Hit";
            }
        }
    }
