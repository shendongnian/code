    public GameObject ParentCamera;
    void Update()
    {
        if (Input.GetMouseButton (0)) 
        {
            cam.transform.position = new Vector3(-100f, -100f, -100f);
        }
    }
