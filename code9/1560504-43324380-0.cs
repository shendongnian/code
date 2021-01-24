    void buatobjek (){
        // ....
        EventTrigger eventTrigger1 = target1.AddComponent<EventTrigger> ();
        EventTrigger.Entry entry = new EventTrigger.Entry( );
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener( ( data ) => { OnPointerDownDelegate( (PointerEventData)data ); } );
        eventTrigger1.triggers.Add( entry );
    }
    public void OnPointerDownDelegate( PointerEventData data )
    {
        Debug.Log( "OnPointerDownDelegate called." );
    }
