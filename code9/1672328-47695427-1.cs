    void Damage(int i)
    {
        // at this time, the first Coroutine, started in InitiateKill, should stop, because otherwise it tries to destroy the target twice
        StopIfAlreadyRunning(i);
        Coroutine crt = StartCoroutine(TargetDie(i, 0));
        //Add to Dictionary
        dyingTarget.Add(i, crt);
    }
    void StopIfAlreadyRunning(int i)
    {
        Coroutine crtOut;
        //Retrieve and stop old coroutine if it exist then removes it
        if (dyingTarget.TryGetValue(i, out crtOut))
        {
            StopCoroutine(crtOut);
            dyingTarget.Remove(i);
        }
    }
