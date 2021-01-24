          protected void radioChkCert_CheckedChanged(object sender, EventArgs e)
         {
	     radiobutton radiobtn = (radiobutton)sender;
	     if ((radiobtn.Checked == true)) {
		 string txt = (((Label)radiobtn.Parent.FindControl("l1")).Text); //l1 is the id of a label in the gridview
		 if ((txt == "CertainCode")) {
			Certainpanel.Visible = true;
		}
	    }
        }
