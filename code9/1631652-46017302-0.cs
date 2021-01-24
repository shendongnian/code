    private void UpdateTintColor()
    {
        var color = new Color(tint.GetColorForState(GetDrawableState(), new Color(0)));
        SetColorFilter(color);
    }
    public void SetColorFilter(ColorStateList tint)
    {
        this.tint = tint;
        base.SetColorFilter(new Color(tint.GetColorForState(GetDrawableState(), new Color(0))));
    }
