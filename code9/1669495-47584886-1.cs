    public static void EnabledDisabeldControls(System.Windows.Forms.Control.ControlCollection paramControls, bool enabled)
        {
            foreach (System.Windows.Forms.Control c in paramControls)
            {
                if (c is TextBox)
                    {
                        ((TextBox)c).ReadOnly = !enabled;
                    }
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Enabled = enabled;
                    }
                EnabledDisabeldControls(control.Controls, enabled);
            }
        }
