    void SetEnabledAllChildrenOf(Control control, bool enabled)
    {
        control.Enabled = enabled;
        foreach(Control c in control.Controls)
        {
            SetEnabledAllChildrenOf(c, enabled);
        }
    }
