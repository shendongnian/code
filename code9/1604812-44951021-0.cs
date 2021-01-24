    set
    {
        if(position != value)
        {
            position = value;
            if(IsVisible)
            {
                if(Overlay != null && Overlay.Control != null)
                {
                    Overlay.Control.UpdateMarkerLocalPosition(this);
                }
            }
        }
    }
