    public float speed = 100;
    public Transform obj;
    
    public void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
    
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
    
        obj.transform.position += tempVect;
    }
