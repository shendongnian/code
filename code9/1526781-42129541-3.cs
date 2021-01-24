    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    Vector3 offset;                     // The initial offset from the target.
    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }
    // Call this method where you spawing your target and set the tag and call this mehtod supply tag parameter 
    public void FindTaggedGameObject(string tag)
    {
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").transform; // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("target gameObjects is not present in hierarchy ");
        }
    }
    void FixedUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;
        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
