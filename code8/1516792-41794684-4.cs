    if (Interer.name == "sinkTop") 
    {
        if (sinked)
        {
            Interer.GetComponent<SpriteRenderer> ().sprite = sinkOFF;
            sinked = false;
        }
        else
        {
            Interer.GetComponent<SpriteRenderer> ().sprite = sinkON;
            sinked = true;
        }
    }
    
