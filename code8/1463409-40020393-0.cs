    public GameObject canvas;
    public GameObject buttonPrefab;
    string[] playerChoices = new string[3];
    void Start()
    {
        playerChoices[0] = "Message 1";
        playerChoices[1] = "Message 2";
        playerChoices[2] = "Message 3";
        createButtons();
    }
    void createButtons()
    {
        int i = 0;
        const float yPosOffset = 40f;
        float offsetCounter = 0;
        foreach (string s in playerChoices)
        {
            //Create new Button
            GameObject tempObj = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            //Rename Button
            tempObj.name = "button: " + i;
            //Make the Button child of the Canvas
            tempObj.transform.SetParent(canvas.transform, false);
            Button tempButton = tempObj.GetComponent<Button>();
            //Set Button Text
            tempButton.GetComponentInChildren<Text>().text = playerChoices[i];
            //Set Button Position
            Vector2 pos = Vector2.zero;
            pos.y = offsetCounter;
            Debug.Log(pos.y);
            tempButton.GetComponent<RectTransform>().anchoredPosition = pos;
            tempButton.onClick.AddListener(() => clickAction(tempButton));
            offsetCounter += yPosOffset; //Increment Position
            i++;
        }
    }
    //This function will be called when a Button is clicked
    void clickAction(Button buttonClicked)
    {
        //Debug.Log("Clicked Button: " + buttonClicked.name);
        Debug.Log("Clicked Button: " + buttonClicked.GetComponentInChildren<Text>().text);
    }
