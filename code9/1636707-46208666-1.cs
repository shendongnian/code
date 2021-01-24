      //Clients play their smoke locally depending on the synced variable
      if(smokeOn)
        particleSystem.Play();
      else
        particleSystem.Stop();
    }
    else 
    {
      smokeOn = particleSystem.isPlaying;
    }
