    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coing"))
        {
            Debug.Log("Coing detected. Destorying coin");
            Destroy(collision.gameObject);
        }
    }
