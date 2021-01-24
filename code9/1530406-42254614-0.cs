    void Update()
    {
       if (RoundOver == false)
       {
            RoundOver = true;
            StartCoroutine(Wait());
       }
       if (counter > DelayTime && RoundOver == false)
       {
        counter = 0;
        Debug.Log("Going to spawn a zombie", gameObject);
        SpawnZombie();
       }
       counter += Time.deltaTime;
    }
    IEnumerator Wait()
    {
        Seconds = 3;
        Debug.Log("Waiting", gameObject);
        Debug.Log("ACTUALLY WAITING", gameObject);
        yield return new WaitForSeconds(Seconds);
        Debug.Log("Done Waiting", gameObject);
        RoundNumber += 1;                //Just game stuff
        ZombiesLeft = ZombieAmount();    //Just game stuff
        RoundOver = false;
        Debug.Log("ACTUALLY WAITING DONE", gameObject);
        Debug.Log("Done wit stuff", gameObject);
    }
