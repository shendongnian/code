    public void ButtonController(Button buttonToEnable, Label labelToenable)
    {
        foreach (Control ctrl in panel1.Controls)
        {
            if (ctrl == buttonToEnable || ctrl == labelToenable)
            {
                ctrl.Enabled = true;
            }
            else
            {
                ctrl.Enabled = false;
            }
        }
    }
