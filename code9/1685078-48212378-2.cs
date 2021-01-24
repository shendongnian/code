    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected. Destroying this coin");
            Destroy(gameObject);
        }
    }
