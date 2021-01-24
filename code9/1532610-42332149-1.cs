Dictionary<SOUND_TYPE,AudioClip> sounds = new Dictionary<SOUND_TYPE,AudioClip>();
    void Start()
    {
        source = GetComponent<AudioSource>();
        sounds = new Dictionary<SOUND_TYPE,AudioClip>();`
        loadSounds();
    }
    public void loadSounds()
    {
      Start()
      //loading sounds
      sounds.Add(SOUND_TYPE.DEATCH, Resources.Load<AudioClip>("Sounds/AccelerationLow"));
    }
