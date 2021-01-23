    // This is just to illustrate the limit
    private const double MaxToolLife = 100;
    
        
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // Check the limit first
        if (Convert.ToDouble(txtToolLifeAchieved.Text) > MaxToolLife)
        {
            // If the hidden field is empty show the confirm
            // By default the hidden field is empty, it means that user just
            // pressed the submit button but not the confirmation dialog
            if (string.IsNullOrWhiteSpace(hdnconfirm.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Confirm", "Confirm();", true);
                return;
            }
    
            // If the hidden field is not empty, this postback was made by the confirm
            // So check for the value of the hidden field
            if (hdnconfirm.Value == "Yes")
            {
                // Handle 'Yes'
            }
            else
            {
                // Handle 'No'
            }
        }
        else
        {
            // The limit is not reached
        }
    }
