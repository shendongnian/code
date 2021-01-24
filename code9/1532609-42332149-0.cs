    void Start()
    {
       // here your source is initialized make sure that GetComponent<AudioSource>() does not return null. 
       // To initialize this directory right use  Dictionary<SOUND_TYPE,AudioClip> sounds = new Dictionary<SOUND_TYPE,AudioClip>();
       source = GetComponent<AudioSource>();
       loadSounds();
    }
    public void loadSounds()
    {
      Start()
    //loading sounds
    sounds.Add(SOUND_TYPE.DEATCH, Resources.Load<AudioClip>("Sounds/AccelerationLow"));
    }
