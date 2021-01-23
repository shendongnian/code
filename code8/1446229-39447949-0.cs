    public GameObject gameObjectToRotate;
    Vector3 defaultAngle;
    float minRot = 30f;
    float maxRot = 30f;
    // Use this for initialization
    void Start()
    {
        defaultAngle = gameObjectToRotate.transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float offset = defaultAngle.z - gameObjectToRotate.transform.eulerAngles.z;
            //Check if we are within min, max rot
            if (offset < minRot && offset > -maxRot)
            {
                gameObjectToRotate.transform.Rotate(0, 0, 1);
                Debug.Log("Rotating!");
            }
        }
    }
