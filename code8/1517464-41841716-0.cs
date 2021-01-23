    public int SliderPos
    {
        set
        {
            if (valueChangedManually()) // <-- magic function
                ManualChangeFunction();
        }
        // ... etc ...
    }
    void ChangeSliderPosManually()
    {
        SliderPos = 100;
    }
