        private void btnRegisterUser_Click(object sender, System.EventArgs e)
    {
        foreach (Control control in this.Controls)
        {
            // Set focus on control
            control.Focus();
            // Validate causes the control's Validating event to be fired,
            // if CausesValidation is True
            if (!Validate())
            {
                DialogResult = DialogResult.None;
                return;
            }
        }
    }
