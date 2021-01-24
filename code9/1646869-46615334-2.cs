    protected void Button_Append_New_Note_Click(object sender, EventArgs e)
    {
        string bondID = Request.QueryString["BondID"];
        // Save the new note...
        Response.Redirect("http://example.com/Page.aspx?BondID=" + bondID);
    }
