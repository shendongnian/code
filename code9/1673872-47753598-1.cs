    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Destroy(other.gameObject);
        }
    }
