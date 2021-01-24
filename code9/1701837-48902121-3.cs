    private Rigidbody rb;
    public bool IsKinematic
    {
        get
        {
            return rb.isKinematic;
        }
        set
        {
            rb.isKinematic = value;
        }
    }
