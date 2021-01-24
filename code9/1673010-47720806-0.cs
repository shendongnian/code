    bool red = true;
    
    // Use this for initialization
    void Start()
    {
        //Use red as default
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Flip whatevet red variable is
            red = !red;
    
            if (red)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
