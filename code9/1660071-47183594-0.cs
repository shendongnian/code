    foreach (HtmlElement element in webBrowser1.Document.All)
    {
        System.Web.UI.HtmlControls.HtmlInputCheckBox _cbx = element as System.Web.UI.HtmlControls.HtmlInputCheckBox;
        if (_cbx != null)
        {
            if (_cbx.Checked)
            {
                //Do something: 
                Response.Write(_cbx.Name + " was checked.<br />");
            }
        }
    }
