    bool triggered = false;
    
    private void Update()
    {
        if (triggered)
        {
            //Do something!
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("SomeObject"))
        {
            triggered = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
    
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("SomeObject"))
        {
            triggered = false;
        }
    }
