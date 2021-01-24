    [SerializeField]
    Button openButton, closeButton;
    [SerializeField]
    GameObject OPTION_UI;//parent
    [SerializeField]
    GameObject open_option_button, close_option_button;
    [SerializeField]
    GameObject[] settings;
    [SerializeField]
    Toggle[] toggle;
    bool Found = false;
     void Start()
    {
        OPTION_UI.SetActive(false);
        Button OPENBUTTON = openButton.GetComponent<Button>();
        Button CLOSEBUTTON = closeButton.GetComponent<Button>();
        OPENBUTTON.onClick.AddListener(OpenUI);
        CLOSEBUTTON.onClick.AddListener(CloseUI);
        toggle[2].isOn = true;
        //fog
        if (PlayerPrefs.GetInt("SaveFog") == 1)
        {
            toggle[0].isOn = true;
        }
        else
        {
            toggle[0].isOn = false;
        }
        //camera
        if (PlayerPrefs.GetInt("SaveCamera") == 1)
        {
            toggle[1].isOn = true;
        }
        else
        {
            toggle[1].isOn = false;
        }
        //livestreaming
        if (PlayerPrefs.GetInt("SaveLiveStream") == 1)
        {
            toggle[2].isOn = true;
        }
        else
        {
            toggle[2].isOn = false;
        }
        //rendering
        if (PlayerPrefs.GetInt("SaveRendering") == 1)
        {
            toggle[3].isOn = true;
        }
        else
        {
            toggle[3].isOn = false;
        }
    } 
     void Update()
    {
        if (Found)
        {
            StartCoroutine(GameOptions());
        } else
        { 
            StopCoroutine(GameOptions());
        }
    }
    IEnumerator GameOptions()
    {
        /*
         * fog , camera
         * livestream, rendering
         * */
        //get the options
        settings = GameObject.FindGameObjectsWithTag("MobileOption");
        
        //fog
        if (toggle[0].isOn == true)
        {
            PlayerPrefs.SetInt("SaveFog", 1);
        } else
        {
            PlayerPrefs.SetInt("SaveFog", 0);
        }
        //camera
        if (toggle[1].isOn == true)
        {
            PlayerPrefs.SetInt("SaveCamera", 1);
        } else
        {
            PlayerPrefs.SetInt("SaveCamera", 0);
        }
        //livestream
        if (toggle[2].isOn == true)
        {
            PlayerPrefs.SetInt("SaveLiveStream" , 1);
        } else
        {
            PlayerPrefs.SetInt("SaveLiveStream", 0);
        }
        //rendering
        if (toggle[3].isOn == true)
        {
            PlayerPrefs.SetInt("SaveRendering", 1);
        } else
        {
            PlayerPrefs.SetInt("SaveRendering", 0);
        }
        yield return null;
    }
    //activate UI
    void OpenUI()
    {
        Found = true;
        open_option_button.SetActive(false);
        close_option_button.SetActive(true);
        OPTION_UI.SetActive(true);
    }
    //deactivate UI
    void CloseUI()
    {
        Found = false;
        open_option_button.SetActive(true);
        close_option_button.SetActive(false);
        OPTION_UI.SetActive(false);
        
    }
