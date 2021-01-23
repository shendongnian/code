    protected void Validate_AlphanumericOrNumeric(object sender, EventArgs e)
    {
        System.Text.RegularExpressions.Regex numeric = new System.Text.RegularExpressions.Regex("^[0-9]+$");
        System.Text.RegularExpressions.Regex alphanemeric = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
        System.Text.RegularExpressions.Regex alphabets = new System.Text.RegularExpressions.Regex("^[A-z]+$");
        string IsAlphaNumericOrNumeric = string.Empty;
        if (numeric.IsMatch(txtText.Text))
        {
            //do anything
        }
        else
        {
            if (alphabets.IsMatch(txtText.Text))
            {
                //do anything
            }
            else if (alphanemeric.IsMatch(txtText.Text))
            {
                //do anything
            }
        }
     
     
        
    }
