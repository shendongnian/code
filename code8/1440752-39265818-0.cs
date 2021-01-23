    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("head")){
            //Run My Code
            Debug.Log("Head Triggered!");
        }
        else if (col.CompareTag("hand"))
        {
            //Run My Code
            Debug.Log("Hand Triggered!");
        }
        else if (col.CompareTag("leg"))
        {
            //Run My Code
            Debug.Log("Leg Triggered!");
        }
    }
