    bool isIn = false;
    void OnTriggerEnter(Collision col)
    {
         isIn = true;
    }
    void OnTriggerExit(Collision col)
    {
         isIn = false;
    }
    
    void Update()
    {
         if (Input.GetMouseButtonUp(0) && isIn == true){ Action();}
    }
