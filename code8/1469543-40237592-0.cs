    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            audio.Play(); //Play it
    
            other.ChildGameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
