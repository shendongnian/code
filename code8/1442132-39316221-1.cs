    public Button[] Btn;
    
    void OnEnable()
    {
        //Register Button Events
        for (int i = 0; i < Btn.Length; i++)
        {
            int btIndex = i;
            string btText = Btn[btIndex].GetComponentInChildren<Text>().text;
            Btn[i].onClick.AddListener(() => buttonCallBack(btText));
        }
    }
    
    private void buttonCallBack(string buttonText)
    {
        Debug.Log(buttonText);
    }
    
    void OnDisable()
    {
        //Un-Register Button Events
        for (int i = 0; i < Btn.Length; i++)
        {
            Btn[i].onClick.RemoveAllListeners();
        }
    }
