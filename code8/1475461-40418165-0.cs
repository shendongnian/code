    public InputField username;
    public InputField password;
    public List<string> usernamelist;
    public Button enter;
    public ScrollRect usernamedataload;
    // Use this for initialization
    void Start()
    {
        string temp = "";
        if (PlayerPrefs.GetString("username") == null)
        {
            username.text = temp;
        }
        else if (PlayerPrefs.GetString("password") == null)
        {
            password.text = temp;
        }
        else
        {
            username.text = PlayerPrefs.GetString("username");
            password.text = PlayerPrefs.GetString("password");
        }
        usernamedataload.gameObject.SetActive(false);
        enter.onClick.AddListener(enterKeyDown);
        username.onValueChanged.AddListener(delegate { selectUsernameInput(); });
        username.onEndEdit.AddListener(delegate { endEditingUsernameInput(); });
    }
    // Update is called once per frame
    void Update()
    {
    }
    void selectUsernameInput()
    {
        usernamedataload.gameObject.SetActive(true);
        usernamedataload.content.GetChild(0);
    }
    void endEditingUsernameInput()
    {
        usernamedataload.gameObject.SetActive(false);
    }
    void enterKeyDown()
    {
    }
