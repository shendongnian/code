    public Texture texA;
    public Texture texB;
    
    const int buttonCount = 25;
    
    public GameObject buttonPrefab;
    public Canvas canvasForButtons;
    
    Button[] buttons = new Button[buttonCount];
    static Vector2[] loc = new Vector2[buttonCount];
    bool[] visited = new bool[buttonCount];
    
    
    void Start()
    {
        int i = 0;
        while (i < loc.Length)
        {
            loc[i] = new Vector2(Random.Range(Screen.width * 0.1f, Screen.width * 0.9f), Random.Range(Screen.height * 0.1f, Screen.height * 0.9f));
            i = i + 1;
        }
    
        createButtons();
    }
    
    void createButtons()
    {
        for (int i = 0; i < loc.Length; i++)
        {
            //Instantiate Button
            GameObject tempButtonObj = Instantiate(buttonPrefab, canvasForButtons.transform) as GameObject;
            Button tempButton = tempButtonObj.GetComponent<Button>();
            buttons[i] = tempButton;
    
            //Create rect for position
            Rect buttonRect = new Rect(loc[i].x, loc[i].y, Screen.width * 0.025f, Screen.height * 0.05f);
    
            //Assign Position of each Button
            buttons[i].GetComponent<RectTransform>().position = buttonRect.position;
            //buttons[i].GetComponent<RectTransform>().sizeDelta = buttonRect.size;
    
            //Don't capture local variable
            int tempIndex = i;
            //Add click Event
            buttons[i].onClick.AddListener(() => buttonClickCallBack(tempIndex));
        }
    }
    
    //Called when Button is clicked
    void buttonClickCallBack(int buttonIndex)
    {
        Debug.Log(buttonIndex);
    
        //Get Texture to change
        Texture textureToUse = visited[buttonIndex] ? texA : texB;
    
        //Convert that Texture to Sprite
        Sprite spriteToUse = Sprite.Create((Texture2D)textureToUse, new Rect(0.0f, 0.0f, textureToUse.width,
            textureToUse.height), new Vector2(0.5f, 0.5f), 100.0f);
    
        //Change the Button Image
        buttons[buttonIndex].image.sprite = spriteToUse;
    
        //Flip Image
        visited[buttonIndex] = !visited[buttonIndex];
    }
