    public void Interrupt()
    {
        _interrupt = true;
    }
    // in some update :
    if ( gotHitThisFrame == true )
        Interrupt();
