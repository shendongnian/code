     protected override void RenderContents(HtmlTextWriter writer)
        {
    
            UserControl uc = new UserControl();
            AADQuickFilter CustomFilter = (AADQuickFilter)uc.LoadControl("~/EmbeddedWebResource/AADGridView.dll/AADGridView.AADQuickFilter.ascx");
            TextWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            CustomFilter.RenderControl(hw);
    
            writer.Write(tw.ToString());
            base.RenderContents(writer);
        }
