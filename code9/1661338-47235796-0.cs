    <asp:DropDownList runat="server" ID="ddlRequestNo" AutoPostBack="true">
            <asp:ListItem Text="111" />
            <asp:ListItem Text="222" />
            <asp:ListItem Text="333" />
            <asp:ListItem Text="444" />
    </asp:DropDownList>
    protected void Page_Load(object sender, EventArgs e)
            {
                ddlRequestNo.SelectedIndexChanged += DdlRequestNo_SelectedIndexChanged;
            }
    private void DdlRequestNo_SelectedIndexChanged(object sender, EventArgs e)
            {
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri+ "?ReqID=" + ddlRequestNo.SelectedItem.Text.ToString());
            }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
                ddlRequestNo.SelectedIndex = ddlRequestNo.Items.IndexOf(ddlRequestNo.Items.FindByText(Request.QueryString["ReqID"].ToString()));
        Response.Redirect("GPApproveCheque.aspx?ReqID="+ddlRequestNo.SelectedItem.Text.ToString());
    
            }
