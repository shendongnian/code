    Renderer yourRenderer;
    bool red = true;
    // Use this for initialization
    void Start()
    {
        yourRenderer = gameObject.GetComponent<Renderer>();
        //Use red as default
        yourRenderer.material.color = Color.red;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            //Flip the boolean variable to the opposite of what it is
            red = !red;
    
            //If true, use red color
            if (red)
            {
                yourRenderer.material.color = Color.red;
            }
            //If false, use green color
            else
            {
                yourRenderer.material.color = Color.green;
            }
        }
    }
