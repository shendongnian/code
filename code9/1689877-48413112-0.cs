    void RFunction(int aProceed = 0)
    {
       if (aProceed == 0)
          if (AskUser())          
             aProceed++;
          else
             aProceed--;
        if (proceed > 0 && other tests)
        {
            // We have to ask here because we only ask if (other tests)           
            RFunction(aProceed);
        }
    }
