    //All the Audios to play
    public AudioClip[] speech;
    public AudioSource auSource;
    
    //Converts nae of audio to the index number
    int findAudio(string audioName)
    {
        for (int i = 0; i < speech.Length; i++)
        {
            if (speech[i].name == audioName)
            {
                return i;
            }
        }
        return -1;
    }
    
    IEnumerator speek(string word)
    {
        //Convert the string to the audioClip index 
        int audioIndex = findAudio(word);
    
        if (audioIndex != -1)
        {
            //Assign the clip to play
            auSource.clip = speech[audioIndex];
    
            //Play
            auSource.Play();
    
            //Wait until audio is done playing
            while (auSource.isPlaying)
            {
                yield return null;
            }
        }
    }
    
    IEnumerator PlayerSpeaker()
    {
        yield return speek("Hello");
        yield return new WaitForSeconds(1f);
        yield return speek("Israel Abebe");
        yield return new WaitForSeconds(1f);
        yield return speek("How are you today?");
    
        yield return null;
    }
    
    // Use this for initialization
    void Start()
    {
        StartCoroutine(PlayerSpeaker());
    }
