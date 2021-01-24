    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player")) {
            isFalling = true;
        }
        else
        {
            Instantiate(gameObject, startPosition, startRotation);
            Destroy(gameObject);
        }
    }
