    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            AudioSource audio = other.GetComponent<AudioSource>(); //Get audio from object
            audio.Play(); //Play it
    
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
