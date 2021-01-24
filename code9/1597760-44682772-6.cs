    private static IEnumerator WaitUntilResolved(WWW request)
    {
        float timeout = 5000, timer = 0;
    
        while (!request.isDone)
        {
            Debug.Log("Download Stat: " + request.progress);
    
            timer += Time.deltaTime;
            if (timer >= timeout)
            {
                Debug.Log("Timeout happened");
                //Break out of the loop
                yield break;
            }
            //Wait each frame in each loop OR Unity would freeze
            yield return null;
        }
    
        if (string.IsNullOrEmpty(request.error))
        {
            //Success
        }
    }
