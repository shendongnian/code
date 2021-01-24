    private m_bIsTerminating = false;
    protected void chk_CheckedChanged(object sender, EventArgs e)
	{
		Response.Redirect("Default2.aspx", false);
		Context.ApplicationInstance.CompleteRequest();
		m_bIsTerminating = true;
	}
    protected void btnRedirect_Click(object sender, EventArgs e)
	{
		lblNotes.Text = "button click event";
	}
    protected override void RaisePostBackEvent(IPostBackEventHandler 
        sourceControl, string eventArgument)
    {
        if (m_bIsTerminating == false)
        base.RaisePostBackEvent(sourceControl, eventArgument);
    }
    protected override void Render(HtmlTextWriter writer)
    {
        if (m_bIsTerminating == false)
        base.Render(writer);
    }
