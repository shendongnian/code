    public AudioClip[] fireSounds;
    AudioSource bulletAudio;
    
    //Every 0.5 seconds(Change this to your needs)
    const float coolDownTime = 0.5f;
    float startingTime = 0f;
    
    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
        startingTime = Time.time;
    }
    
    void Update()
    {
    
        if (Input.GetKey(KeyCode.Space))
        {
            //Check if we have reached the cool down timer
            if (Time.time > startingTime + coolDownTime)
            {
                //We have. Now reset timer
                startingTime = Time.time;
    
                playAudio();
            }
        }
    }
    
    void playAudio()
    {
        bulletAudio.PlayOneShot(fireSounds[UnityEngine.Random.Range(0, fireSounds.Length)]);
        UnityEngine.Debug.Log("Shot");
    }
