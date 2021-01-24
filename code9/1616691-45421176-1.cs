    try
    {
    	var errorProviders = new List<ErrorProvider>() { epEmail, epAlternative, epMobile, epTown, epLandline, epHouseName, epForeName, epSurname, epPostcode, epCountry, epHouseName, epLocality, epCounty };
    
    	if (string.IsNullOrWhiteSpace(txt_ForeName.Text) && string.IsNullOrWhiteSpace(txt_SurName.Text))
    	{
    		epBothNames.SetError(txt_SurName, "Error:"); 
    		epBothNames.SetError(txt_ForeName, "Error:");
    		return false;
    	}
    		
    	if (cmb_Title.SelectedIndex == -1)
    	{   
    		epTitle.SetError(cmb_Title, "Title"); 
    		return false; 
    	}
    	
    	if (cmb_PrefConTime.SelectedIndex == -1)
    	{   
    		epPrefConTime.SetError(cmb_PrefConTime, "Error in: prefered contact time feild");
    		return false; 
    	}
    	
    	if (!isPhoneNumber())
    	{   
    		epPrefConNumber.SetError(cmb_PrefConNumber, "Error");
    		return false; 
    	}
    	
    	foreach (Control c in panel1.Controls.Where(x => x is SpellBox || x is TextBox))
    	{
    		if (!errorProviders.Any(e => e.GetError(c).Length > 0))
    		{ 
    			return false; 
    		}
    	}
    }
    catch (Exception ex)
    {
    	MessageBox.Show(ex.ToString())+ "Error has occurred, Please cancel and try again!");
    }
    return true;
