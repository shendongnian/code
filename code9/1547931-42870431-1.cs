    <form id="form1" runat="server">
        <div id="dvLeft"></div>
        <div id="dvRight"></div>
        <div id="dvMiddle"></div>
        <div id="dvBottom">
            <asp:DropDownList ID="ddlTheme" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTheme_SelectedIndexChanged">
                <asp:ListItem Value="FirstTheme">FirstTheme</asp:ListItem>
                <asp:ListItem Value="SecondTheme">SecondTheme</asp:ListItem>
                <asp:ListItem Value="ThirdTheme">ThirdTheme</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
    
    protected void ddlTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        // save value into a session variable
        Session["SelectedTheme"] = ddlTheme.SelectedValue;
    }
    protected void PreRender()
    {
        // works when page reloads
        if (Session["SelectedTheme"] != null){
            Page.Theme = Session["SelectedTheme"].ToString();
        }
        // following line works on postback only
        //Page.Theme = ddlTheme.SelectedValue;
    }
