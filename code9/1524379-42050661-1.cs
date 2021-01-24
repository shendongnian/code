    private float startWait = 3f;   //Amount of time to wait before first wave
    private float waveWait = 2f;    //Amount of time to wait between spawning each wave
    private float spawnWait = 0.5f; //Amount of time to wait between spawning each enemy
    
    
    private float startTimer = 0f; //Keep track of time that has elapsed since game launch
    private float waveTimer = 0f;  //Keep track of time that has elapsed since last wave
    private float spawnTimer = 0f; //Keep track of time that has elapsed since last spawn
    
    private List<GameObject> zombies = new List<GameObject>();
    
    [SerializeField]
    private Transform spawnPoints; //The parent object containing all of the spawn point objects
    
    
    void Start()
    {
        deathUI.SetActive(false);
    
        //Set the default number of zombies to spawn per wave
        zombieCount = 5;
    
        PopulateZombies();
        StartCoroutine(SpawnWaves());
    }
    
    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer >= startWait)
        {
            waveTimer += Time.deltaTime;
            spawnTimer += Time.deltaTime;
        }
    
    
        //When the player dies "pause" the game and bring up the Death screen
        if (Player.isDead == true)
        {
            Time.timeScale = 0;
            deathUI.SetActive(true);
        }
    
    }
    
    IEnumerator SpawnWaves()
    {
        //wait 3 seconds
        yield return new WaitForSeconds(startWait);
        //then:
        while (!Player.isDead && ScoreCntl.wave < 9)
        {
            if (waveTimer >= waveWait)
            {
                IncrementWave();
                for (int i = 0; i < zombieCount; i++)
                {
                    if (spawnTimer >= spawnWait)
                    {
                        Vector3 spawnPosition = spawnPoints.GetChild(Random.Range(0, spawnPoints.childCount)).position;
                        Quaternion spawnRotation = Quaternion.identity;
                        GameObject created = Instantiate(zombies[0], spawnPosition, spawnRotation);
                        TransformCreated(created);
    
                        spawnTimer = 0f;
                    }
                }
    
                waveTimer = 0f;
            }
            //wait until the end of frame
            yield return null;
        }
    }
