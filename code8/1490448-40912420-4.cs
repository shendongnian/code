    SlowDown()
      {
      void SlowlySlowForFiveSeconds()
        {
        InvokeRepeating("SlowSteps", 0f, .5f);
        Invoke("NormalSpeed", 5f);
        }
      void SlowSteps()
        {
        speed = speed * .9f;
        }
      void NormalSpeed()
        {
        CancelInvoke("SlowSteps");
        speed = normal speed;
        }
      }
