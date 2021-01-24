    Dictionary<Collider2D, BoxManager> scriptID = new Dictionary<Collider2D, BoxManager>();
    public BoxManager boxManagerPrefab;
    
    void Start()
    {
        //Register your BoxManager instances to the Dictionary
        for (int i = 0; i < 5; i++)
        {
            BoxManager bc = Instantiate(boxManagerPrefab) as BoxManager;
            //Use Isntance ID of the Script as id
            Collider2D cld2D = boxManagerPrefab.GetComponent<Collider2D>();
            scriptID.Add(cld2D, bc);
        }
    }
    
    void OnTriggerStay2D(Collider2D target)
    {
        if (target.CompareTag("Box"))
        {
            BoxManager result = scriptID[target];
    
            if (result.isHeld == false)
            {
                target.attachedRigidbody.AddForce(transform.right * thrust);
    
                target.GetComponent<BoxManager>();
            }
        }
    }
