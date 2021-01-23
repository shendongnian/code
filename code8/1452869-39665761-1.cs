    private bool _allowPlayerMovement;
    public Room FirstRoom;
    public Room SecondRoom;
    public Room ThirdRoom;
    //...
    public void Awake()
    {
        _allowPlayerMovement = false;
        StartCoroutine(LoadRooms())
    }
    
    private IEnumerator LoadRooms()
    {
        //Runs the LoadFirstRoom Coroutine then waits for it to finish.
        yield return StartCoroutine(LoadFirstRoom())
        
        //One the first routine finishes set the variable to true.
        _allowPlayerMovement = true;
    
        //Start loading the 2nd room, wait for it to finish
        yield return StartCoroutine(LoadSecondRoom())
    
        //Once the 2nd room is finished loading start loading the 3rd room.
        yield return StartCoroutine(LoadThirdRoom())
    
       //... And so on
    }
    
    private IEnumerator LoadFirstRoom()
    {
       WWW www = new WWW("http:\\example.com\levels\FirstRoom.json")
       yield return www;
       FirstRoom = FromJson<Room>(www.text);
    }
    
    //... And so on
