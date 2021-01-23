    protected void txtboxPlate_TextChanged(object sender, EventArgs e)
        {
			//Catching code
			if (txtboxPlate.Text != "")			
			{
				if (txtboxPlate.Text == "plate number")
				{
					//will check database for "plate number" and do stuff on enter.
				}
				else
				{
                    resetforms();// on enter
				}
			}
            
        else
        {
            the text has changed by user, but has clicked a button and needs nothing to happen because of this text change
        }
