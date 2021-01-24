    bool isTouching = false;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("YourOtherObject"))
        {
            isTouching = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("YourOtherObject"))
        {
            isTouching = false;
        }
    }
