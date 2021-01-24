    if(!String.IsNullOrWhitespace(ccddl1.SelectedValue.ToString())
    {
    	mail.CC.Add(new MailAddress(ccddl1.SelectedValue.ToString());
    }
    
    if (!String.IsNullOrWhitespace(ccddl2.SelectedValue.ToString())
    {
       mail.CC.Add(new MailAddress(ccddl2.SelectedValue.ToString()));
    }
