    void OnTriggerEnter2D(Collider2D other) 
    {
         StartCoroutine(PowerUp());
    }
     
    private IEnumerator PowerUp()
    {
        countDown = 10f;       
        while (countDown >= 0)
        {
            // Logic during the 10 seconds
            countDown -= Time.smoothDeltaTime;
            yield return null;
        }         
    }
