    List<float> timer = new List<float>();
    
    IEnumerator executeInWithFixedTiming()
    {
        float counter = 0;
    
        //Loop through the timers
        for (int i = 0; i < timer.Count; i++)
        {
            //Wait until each timer passes
            while (counter <= timer[i])
            {
                counter += Time.deltaTime;
                //Wait for a frame so that we don't freeze Unity
                yield return null;
            }
    
            //TIMER has matched the current timer loop.
            //Do something below
            Debug.Log("TIMER REACHED! The current timer is " + timer[i] + " in index: " + i);
        }
    
        //You can now clear timer if you want
        timer.Clear();
    }
