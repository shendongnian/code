    private void SetAppearance()
    {
        if (backcolor != null)
            base.BackColor = enabled ? backcolor.Enabled : backcolor.Disabled;
        if (forecolor != null)
            base.ForeColor = enabled ? forecolor.Enabled : forecolor.Disabled;
    }
