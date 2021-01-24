    if (showControl == true)
    {
        //create an instance of the user control
        WebUserControl1 control1 = (WebUserControl1)LoadControl("~/WebUserControl1.ascx");
    
        //add it to the page when needed
        PlaceHolder1.Controls.Add(control1);
    }
