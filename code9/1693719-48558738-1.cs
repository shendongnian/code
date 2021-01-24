    private const float _tickInterval = 1f 
    public void Start()
    {
        // your code
        // ...
        
        StartCoroutine(AiTick);
    }
    public IEnumerator AiTick();
    {
        while(true)
        {
            GetNewPath(); 
            yield return new WaitForSeconds(_tickInterval);
        }
    }
    public void OnDestroy()
    {
        StopAllCoroutines();
    }
