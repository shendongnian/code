    foreach (Control item in pnlFilter.Controls)
    {
        HtmlInputCheckBox _cbx = item as HtmlInputCheckBox;
        if (_cbx != null)
        {
            if (_cbx.Checked)
            {
                //Do something: 
                Response.Write(_cbx.Name + " was checked.<br />");
            }
        }
    }
