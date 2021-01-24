    void Awake()
    {
        AudioSource source = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter(Collider other) {
       if(other.tag == "point")
          source.volume = 0.1f;
    }
    
    void OnTriggerExit(Collider other) {
       if(other.tag == "point")
          source.volume = 1f;
    }
