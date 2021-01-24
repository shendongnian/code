    private UnityEngine.UI.Toggle[] toggles;
    
    void Start()
    {
        toggles = GetComponentsInChildren<UnityEngine.UI.Toggle>();
    
        if( toggles.Length > 0 )
        {
            for( int i = 0 ; i < toggles.Length ; ++i )
            {
                int closureIndex = i ;
                toggles[closureIndex].interactable = false ;
                toggles[closureIndex].onValueChanged.addListener( (isOn) =>
                   if( isOn )
                   {
                        toggles[closureIndex].interactable = false;
                        if( closureIndex < toggles.Length - 1 )
                            toggles[closureIndex + 1].interactable = true ;
                   }
                ) ;
            }
            toggles[0].interactable = true ;
        }
        else
             Debug.LogError("No toggle component in children!", this ) ;
    }
