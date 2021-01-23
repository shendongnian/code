    public AudioSource soundToPlay;
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player") {
            soundToPlay.Play ();
        }
    }
