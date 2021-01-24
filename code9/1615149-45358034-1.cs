    private UnityEngine.UI.Text textComponent;
    
    void Start()
    {
        //You should do your GetCompoent calls once in Start() and keep the references.
        textComponent = LoadingTxt.GetComponent<UnityEngine.UI.Text>()
    }
    
    IEnumerator LoadData()
    {
        textComponent.enabled = true; //Show the text
        yield return 0; //yielding 0 causes it to wait for 1 frame. This lets the text get drawn.
        ModelLoadFunc(); //Function that loads the models, hang happens here
        textComponent.enabled = false; //Hide the text
    }
