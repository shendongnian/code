    void Update()
    {
        if (playAura)
        {
            Debug.Log("Running");
            particleObject.Play();
            playAura = false;
        }
    }
