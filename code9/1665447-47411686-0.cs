       private void SetStylesToCustomButtons(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is CustomButton)
                {
                    (control as CustomButton).TopColor = Color.Red;
                }
                else if (control is Panel)
                {
                    SetStylesToCustomButtons((control as Panel).Controls);
                }
            }
        }
