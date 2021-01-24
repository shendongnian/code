    GameObject playerball;
    Transform spawpoint;
    bool spaw;
    private void Start(){
        spaw = false;
    }
    private void Update()
    {
        GameObject instance;
        if(!spaw)
        {
            instance = GameObject.Instantiate(playerball, spawpoint.position, spawpoint.rotation);
            spaw=true;
        }
        // Check if instance is not null, and work on it if that's the case.
    }
