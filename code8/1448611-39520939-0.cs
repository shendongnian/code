    class MyLinelessWebControl: System.Web.UI.WebControls.DropDownList()
    {    
        protected override RenderControl(HtmlTextWriter writer)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter tempWriter = new HtmlTextWriter(sw);
            base.RenderControl(tempWriter);
            writer.Write(sw.ToString().Replace("\r\n","");
        }
    }
