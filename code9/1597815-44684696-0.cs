    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerStay)
        {
            //
        }
    }
    
    bool triggerStay = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("InteractiveArea"))
        {
            triggerStay = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("InteractiveArea"))
        {
            triggerStay = false;
        }
    }
