    void RFunction(int aProceed = 0)
    {
        if (aProceed >= 0 && other tests)
        {
          if (aProceed == 0)
             if (AskUser())          
               aProceed++;
            else
               aProceed--;
            // We have to ask here because we only ask if (other tests)           
            RFunction(aProceed);
        }
    }
