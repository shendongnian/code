    void Start()
    {
        PreCountdownLength = 5.0f;
        PreCountdownInterval = 1.0f;
        _onIntroScreen = true;
        UserActive = false;
        _prevMousePosition = Input.mousePosition;
        InvokeRepeating("LastMousePosition", 0, _checkMousePositionTimingInterval); 
    }
    void Update()
    {
        _currentMousePosition = Input.mousePosition;
        // CHECK FOR PLAYER IDLE
        if (_currentScene.name != introScene.name)
        {
            _onIntroScreen = false;
            if (_currentMousePosition != _prevMousePosition)
            {
                UserActive = true;
            }
            else
            {
                UserActive = false;
            }       
        }
        else if (_currentScene.name == introScene.name)
        {
            _onIntroScreen = true;
        }
        // IF IDLE START PRE-COUNT TIMER ELSE DESTROY
        if (!UserActive && !_onIntroScreen)
        {
            if (_preCountdownTimerInstance == null)
                _preCountdownTimerInstance = Instantiate(preCountdownTimerPrefab);
        }
        else if (UserActive)
        {
            if (_preCountdownTimerInstance != null)
                Destroy(_preCountdownTimerInstance);
        }
    }
