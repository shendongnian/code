    protected void Page_Load(object sender, EventArgs e)
    {
    <%-- This part works fine --%>
    TextBox uname = (TextBox)AddItemFv.Row.FindControl("SubmitByTbx");
    if (uname != null)
        uname.Text = Session["RegUser"].ToString();
    TextBox udate = (TextBox)AddItemFv.Row.FindControl("SubmitDTTbx");
    if (udate != null)
        udate.Text = DateTime.Now.ToString("MM/dd/yyyy");
    <%-- This part Fails to stuff the values into the TextBoxes --%>
    TextBox uuname = (TextBox)AddItemFv.Row.FindControl("AssetEnteredByTextBox");
    if (uname != null)
        // correct from uname to uuname
        uuname.Text = Session["RegUser"].ToString();
    TextBox uudate = (TextBox)AddItemFv.Row.FindControl("AssetEnteredTextBox");
    if (udate != null)
        //Corrected from udate to uudate
        uudate.Text = DateTime.Now.ToString("MM/dd/yyyy");
    }
