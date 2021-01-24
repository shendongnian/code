    // Drag & Drop the button into the inspector
    public Button button ;
    
    // Drag & Drop your animator into the inspector
    public Animator animator ;
    void Start( )
    {
        EventTrigger eventTrigger = button.AddComponent<EventTrigger>( );
        
        // Detect when mouse button is pressed down
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry( );
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener( ( data ) => { OnPointerDown( (PointerEventData)data ); } );
        eventTrigger.triggers.Add( pointerDownEntry );
        
        // Detect when mouse button is released
        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry( );
        pointerUpEntry.eventID = EventTriggerType.PointerDown;
        pointerUpEntry.callback.AddListener( ( data ) => { OnPointerUp( (PointerEventData)data ); } );
        eventTrigger.triggers.Add( pointerUpEntry );
    }
    public void OnPointerDown( PointerEventData data )
    {
        Debug.Log( "OnPointerDown called." );
        
        // Stop your animation, supposing you have a bool parameter in your animator
        animator.SetBool("boolName", true);
    }
    public void OnPointerUp( PointerEventData data )
    {
        Debug.Log( "OnPointerUp called." );
        
        // Stop your animation, supposing you have a bool parameter in your animator
        animator.SetBool("boolName", false);
    }
