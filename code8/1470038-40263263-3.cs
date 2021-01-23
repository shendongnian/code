    List<GameObject> reUsableBullets;
    int toUseIndex = 0;
    
    void Start()
    {
        intitOnce();
    }
    
    //Call this function once to create bullets
    void intitOnce()
    {
        reUsableBullets = new List<GameObject>();
    
        //Create 20 bullets then store the reference to a global variable for re-usal
        for (int i = 0; i < 20; i++)
        {
            reUsableBullets[i] = new GameObject("bullet");
            reUsableBullets[i].AddComponent<Rigidbody>();
            reUsableBullets[i].SetActive(false);
        }
    }
    
    void functionCalledVeryOften()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Re-use old bullet
            reUsableBullets[toUseIndex].SetActive(true); 
            Rigidbody tempRgb = reUsableBullets[toUseIndex].GetComponent<Rigidbody>();
            tempRgb.velocity = transform.forward * 50;
            toUseIndex++;
    
            //reset counter
            if (toUseIndex == reUsableBullets.Count - 1)
            {
                toUseIndex = 0;
            }
        }
    }
