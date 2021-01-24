    public static void EnabledDisabeldControls(System.Windows.Forms.Control.ControlCollection paramControls, bool enabled)
        {
            foreach (System.Windows.Forms.Control control in paramControls)
            {
                if (c is TextBox)
                    {
                        ((TextBox)c).ReadOnly = true;
                    }
                    if (c is CheckBox)
                    {
                        ((CheckBox)c).Enabled = false;
                    }
                EnabledDisabeldControls(control.Controls, enabled);
            }
        }
