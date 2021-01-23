    bool isRunning = false;
    IEnumerator activatePanel()
    {
        //Exit if already running
        if (isRunning)
        {
            yield break;
        }
        
        //Not running, now set isRunning to true then run
        isRunning = true;
        yield return new WaitForSeconds(3f);
        pausePanel2.SetActive(true);
    
        WaitForSeconds waitTime = new WaitForSeconds(0.2f);
        for (int i = 0; i <= stars; i++)
        {
            yield return waitTime;
            starText2.text = i.ToString();
        }
        //Done running, set isRunning to false
        isRunning = false;
    }
