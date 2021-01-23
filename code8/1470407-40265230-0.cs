    public IEnumerator spawnCoroutine;
    private float spawnObstacleTimer;
    
    void Start () {
            spawnObstacleTimer = GameObject.Find("EventSystem").GetComponent<gameManager>().spawnObstacleTimer;
            startSpawnCoroutine();
        }
    
    public IEnumerator spawnObsCoroutine(float timer)
        {
            while (true)
            {
                yield return new WaitForSeconds(timer);
                spawnObs();
            }
        }
    
    public void startSpawnCoroutine()
        {
           //Moved the creation of the IEnumerable in to this function.
           spawnCoroutine = spawnObsCoroutine(spawnObstacleTimer);
           StartCoroutine(spawnCoroutine);
        }
    public void stopSpawnCoroutine()
        {
            StopCoroutine(spawnCoroutine);
        }
