    GameObject playerball;
    Transform spawpoint;
    bool spaw;
    GameObject playerballObject;
    private void Start(){
        spaw = false;
    }
    private void Update()
    {
        if(!spaw)
        {
            playerballObject = GameObject.Instantiate(playerball, spawpoint.position, spawpoint.rotation);
            spaw=true;
            // Do any first time modification you need on your object.
        }
        // Use your reference there to update the state of your object.
    }
