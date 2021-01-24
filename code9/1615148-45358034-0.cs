    private UnityEngine.UI.Text textCompoent;
    
    void Start()
    {
        //You should do your GetCompoent calls once in Start() and keep the references.
        textCompoent = LoadingTxt.GetComponent<UnityEngine.UI.Text>()
    }
    
    IEnumerator LoadData()
    {
        textCompoent.enabled = true; //Show the text
        yield return 0; //yielding 0 causes it to wait for 1 frame. This lets the text get drawn.
        Mlf(); //Function that loads the models, hang happens here
        textCompoent.enabled = false; //Hide the text
    }
