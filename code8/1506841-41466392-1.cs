    public float startingOffset = 45;
    public float mod = 2;
    
    
    // Update is called once per frame
    void Update()
    {
        //Rotate it to -45
        transform.Rotate(new Vector3(-startingOffset, 0, 0));
    
        // Move the camera normally
        transform.position += Input.GetAxis("Vertical") * transform.forward * mod;
        transform.position += Input.GetAxis("Horizontal") * transform.right * mod;
    
        //Rotate it back to 45
        transform.Rotate(new Vector3(startingOffset, 0, 0));
    }
