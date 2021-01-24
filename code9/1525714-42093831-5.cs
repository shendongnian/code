    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.tag == "TAG_FOR_KEY")
            GetComponent<DoorScript>().PickUp();
    }
