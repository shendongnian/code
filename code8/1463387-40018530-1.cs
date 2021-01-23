    public Button button1;
    void Start()
    {
        button1.onClick.AddListener(() => NewGame());
    }
    
    void NewGame()
    {
        SceneManager.LoadScene(1);
    }
