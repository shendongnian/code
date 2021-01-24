    public static void FirstControlFocus(this Control ctl)
    {
        ctl.Controls.OfType<Control>()
           .Where(c => c.TabIndex == ctl.Controls.OfType<Control>().Min(t => t.TabIndex))
           .FirstOrDefault()?.Focus();
    }
