    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected. Destorying this coin");
            Destroy(gameObject);
        }
    }
