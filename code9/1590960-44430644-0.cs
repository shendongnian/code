    public UnityEngine.UI.Button button;
    
    private void Start()
    {
        // See https://docs.unity3d.com/ScriptReference/UI.Button-onClick.html
        if( button != null )
            button.onClick.AddListener( () => analog = !analog ) ;
    }
