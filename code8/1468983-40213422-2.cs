    protected void txtboxPlate_TextChanged(object sender, EventArgs e)
        {
			if (txtboxPlate.Text == "plate number")
			{
				//will check database for "plate number" and do stuff on enter.
			}
			else 
			{
				if (e.KeyCode == Keys.Enter) 
				{
					resetforms();// on enter
					button_Click(sender e);
				}
                    
			}
		}
            
    else
    {
        the text has changed by user, but has clicked a button and needs nothing to happen because of this text change
    }
