        void AudioEnable()
        {
            if (SoundPLaying)
                return;            
            if (Input.GetKey(KeyCode.Space))
            {
                SoundPLaying = true;
                System.Timers.Timer timer = new System.Timers.Timer();
                timer.AutoReset = true;
                timer.Interval = 1000;  //1000 milliseconds. Ajust this time to be equal to length of fire sound.
                timer.Elapsed += (s, e) => { SoundPLaying = false; timer.Dispose(); };
                timer.Start();
                Invoke("Audio", audioDelay);
            }
        }
        void Audio()
        {
            AudioSource audio = GetComponent<AudioSource>(); // play fire sounds from array when space is pressed
            audio.PlayOneShot(fireSounds[Random.Range(0, fireSounds.Length)]);
        }
