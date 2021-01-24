    private void Update()
    {
      if(Input.touchCount == 0)
      {
        if(!checkingForInactivity)
        {
          checkingForInactivity = true;
          myRoutine = StartCoroutine(CheckForInactivity());
        }
      }
      else
      {
        if(checkingForInactivity) StopCoroutine(myRoutine);
      }
    }
     Ienumrable CheckForInactivity()
     {
       yield new waitForSecond(3.0f);
       //user is inactive
     }
    }
