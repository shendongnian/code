    public bool IsKinematic
    {
        get
        {
            return rb.isKinematic;
        }
        set
        {
            // Similar to if (OnKinematicValueChange != null) OnKinematicValueChange(this, EventArgs.Empty)
            OnKinematicValueChange?.Invoke(this, EventArgs.Empty);
            rb.isKinematic = value;
        }
    }
