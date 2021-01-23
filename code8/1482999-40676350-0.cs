    public Text CommunicationMessage;
    public Button CommunicationButton;
    void Start()
    {
        CommunicationMessage = GameObject.Find("CrazyMsg").GetComponent<Text>();
        CommunicationButton = GameObject.Find("CommunicationButton").GetComponent<Button>();
        
        //Register Button Click
         CommunicationButton.onClick.AddListener(() => buttonClickCallBack());
    }
    //Will be called when CommunicationButton Button is clicked!
    void buttonClickCallBack()
    {
       CommunicationMessage.text = ....
    }
