    /// <summary>
    /// Allows a the first adjacent tabs to be fixed (no dragging, and default close button will not show).
    /// </summary>
    public int FixedHeaderCount
    {
       get { return (int) GetValue(FixedHeaderCountProperty); }
       set { SetValue(FixedHeaderCountProperty, value); }
    }
