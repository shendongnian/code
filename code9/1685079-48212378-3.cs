    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin detected. Destroying coin");
            Destroy(collision.gameObject);
        }
    }
