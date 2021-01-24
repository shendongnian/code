    //Drag button from the Editor to this
    public Button resetButton;
    
    Vector3 defaultBallPos;
    Quaternion defaultBallRot;
    Vector3 defaultBallScale;
    int score = 0;
    
    
    void Start()
    {
        //Get the starting/default values
        defaultBallPos = transform.position;
        defaultBallRot = transform.rotation;
        defaultBallScale = transform.localScale;
    }
    
    void OnEnable()
    {
        //Register Button Event
        resetButton.onClick.AddListener(() => buttonCallBack());
    }
    
    private void buttonCallBack()
    {
        UnityEngine.Debug.Log("Clicked: " + resetButton.name);
        resetGameData();
    }
    
    void resetGameData()
    {
        //Reset the position of the ball and set everything to the starting postion
        transform.position = defaultBallPos;
        transform.rotation = defaultBallRot;
        transform.localScale = defaultBallScale;
    
        //Reset other values below
    }
    
    void OnDisable()
    {
        //Un-Register Button Event
        resetButton.onClick.RemoveAllListeners();
    }
