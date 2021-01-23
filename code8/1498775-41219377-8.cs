    public GameObject canvas;
    void Start()
    {
        makeToggle();
    }
    void makeToggle()
    {
        GameObject toggleObj = createToggleObj(canvas);
        GameObject bgObj = createBackgroundObj(toggleObj);
        GameObject checkMarkObj = createCheckmarkObj(bgObj);
        GameObject labelObj = createLabelObj(toggleObj);
        attachAllComponents(toggleObj, bgObj, checkMarkObj, labelObj);
    }
    //1.Create a *Toggle* GameObject then make it child of the *Canvas*.
    GameObject createToggleObj(GameObject cnvs)
    {
        GameObject toggle = new GameObject("Toggle");
        toggle.transform.SetParent(cnvs.transform);
        toggle.layer = LayerMask.NameToLayer("UI");
        return toggle;
    }
    //2.Create a Background GameObject then make it child of the Toggle GameObject.
    GameObject createBackgroundObj(GameObject toggle)
    {
        GameObject bg = new GameObject("Background");
        bg.transform.SetParent(toggle.transform);
        bg.layer = LayerMask.NameToLayer("UI");
        return bg;
    }
    //3.Create a Checkmark GameObject then make it child of the Background GameObject.
    GameObject createCheckmarkObj(GameObject bg)
    {
        GameObject chmk = new GameObject("Checkmark");
        chmk.transform.SetParent(bg.transform);
        chmk.layer = LayerMask.NameToLayer("UI");
        return chmk;
    }
    //4.Create a Label GameObject then make it child of the Toggle GameObject.
    GameObject createLabelObj(GameObject toggle)
    {
        GameObject lbl = new GameObject("Label");
        lbl.transform.SetParent(toggle.transform);
        lbl.layer = LayerMask.NameToLayer("UI");
        return lbl;
    }
    //5.Now attach components like Image, Text and Toggle to each GameObject like it appears in the Editor.
    void attachAllComponents(GameObject toggle, GameObject bg, GameObject chmk, GameObject lbl)
    {
        //Attach Text to label
        Text txt = lbl.AddComponent<Text>();
        txt.text = "Toggle";
        Font arialFont =
        (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        txt.font = arialFont;
        txt.lineSpacing = 1;
        txt.color = new Color(50 / 255, 50 / 255, 50 / 255, 255 / 255);
        RectTransform txtRect = txt.GetComponent<RectTransform>();
        txtRect.anchorMin = new Vector2(0, 0);
        txtRect.anchorMax = new Vector2(1, 1);
        //txtRect.y
        //Attach Image Component to the Checkmark
        Image chmkImage = chmk.AddComponent<Image>();
        chmkImage.sprite = (Sprite)AssetDatabase.GetBuiltinExtraResource(typeof(Sprite), "UI/Skin/Checkmark.psd");
        chmkImage.type = Image.Type.Simple;
        //Attach Image Component to the Background
        Image bgImage = bg.AddComponent<Image>();
        bgImage.sprite = (Sprite)AssetDatabase.GetBuiltinExtraResource(typeof(Sprite), "UI/Skin/UISprite.psd");
        bgImage.type = Image.Type.Sliced;
        RectTransform bgRect = txt.GetComponent<RectTransform>();
        bgRect.anchorMin = new Vector2(0, 1);
        bgRect.anchorMax = new Vector2(0, 1);
        //Attach Toggle Component to the Toggle
        Toggle toggleComponent = toggle.AddComponent<Toggle>();
        toggleComponent.transition = Selectable.Transition.ColorTint;
        toggleComponent.targetGraphic = bgImage;
        toggleComponent.isOn = true;
        toggleComponent.toggleTransition = Toggle.ToggleTransition.Fade;
        toggleComponent.graphic = chmkImage;
        toggle.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
    }
