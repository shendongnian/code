    public static void FirstControlFocus(this Control ctl)
    {
        ctl.Controls.OfType<Control>()
           .FirstOrDefault(c => c.TabIndex == ctl.Controls.OfType<Control>().Min(t => t.TabIndex))
          ?.Focus();
    }
