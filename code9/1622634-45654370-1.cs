    void Start()
    {
        StartCoroutine(incremental());
    }
    
    IEnumerator incremental()
    {
        while (true)
        {
            //Wait for 30 seconds
            yield return new WaitForSeconds(30);
    
            //Increment Speed
            incrementSpeed();
        }
    
    }
    
    void incrementSpeed()
    {
        speed += 4;
    }
