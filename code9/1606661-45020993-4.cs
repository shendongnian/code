    foreach (Control control in this.TabList.Controls)
    {
        if (control.GetType()==typeof(HtmlGenericControl))
        {
            var tab = (HtmlGenericControl)control;
            tab.Attributes["class"] = tab.Attributes["class"].Replace("disabled", "");
        }
    }
