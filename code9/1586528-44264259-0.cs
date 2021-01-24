    private UnityEngine.UI.Toggle toggle;
    
    void Start()
    {
        toggle = GetComponentInChildren<UnityEngine.UI.Toggle>();
        if( toggle != null )
             toggle.onValueChanged.addListener( OnToggleValueChanged ) ;
        else
             Debug.LogError("No toggle component in children!", this ) ;
    }
    
    private void OnToggleValueChanged( bool isOn )
    {
        if( isOn )
        {
            toggle.onValueChanged.removeListener( OnToggleValueChanged ) ;
            toggle.interactable = false;
        }
    }
