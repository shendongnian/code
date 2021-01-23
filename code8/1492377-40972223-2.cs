    // inside ButtonScript.Start() or ButtonScript.Awake()
    this/* Button */.onClick.AddListener(new UnityEngine.Events.UnityAction<string>(ButtonClicked));
    // and now make a new method inside ButtonScript
    void ButtonClicked()
    {
        // method with tags:
        Debug.Log(gameObject.Tag == "YesButton" ? : "Yes" : "No");
        // method with enumeration:
        Debug.Log(_myType.ToString());
    }
