    public void Validate_Form(object sender, EventArgs e)
        {
            Validate();
            // Check that the page is loaded due to a postback:
            if (IsPostBack)
            {
                // Check that the page passed validation:
                if (IsValid)
                {
                    // perform some logic...
                }
            }
        }
