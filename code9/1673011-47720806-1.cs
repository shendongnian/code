    bool red = true;
    
    // Use this for initialization
    void Start()
    {
        //Use red as default
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Flip the boolean variable to the opposite of what it is
            red = !red;
    
            //If true, use red color
            if (red)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            //If false, use green color
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
