    void Start()
    {
        Invoke("DestroyMyObject", 5);
    }
    void DestroyMyObject()
    {
        this.Destroy(this.gameObject);
    }
