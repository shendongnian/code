      if(smokeOn)
        particleSystem.Play();
      else
        particleSystem.Stop();
    }
    else 
    {
      smokeOn = particleSystem.isPlaying;
    }
