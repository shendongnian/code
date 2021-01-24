    <body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddl2_selectindexchange">
        </asp:DropDownList>
    </div>
    </form>
    </body>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<string> str = new List<string>();
            str.Add("red");
            str.Add("blue");
            str.Add("black");
            List<string> str2 = new List<string>();
            str2.Add("red");
            str2.Add("blue");
            str2.Add("black");
            DropDownList1.DataSource = null;
            DropDownList1.DataSource = str;
            DropDownList1.DataBind();
            DropDownList2.DataSource = null;
            DropDownList2.DataSource = str2;
            DropDownList2.DataBind();
        }
    }
    protected void ddl2_selectindexchange(object sender, EventArgs e)
    {
        DropDownList ddl = new DropDownList();
        ddl = sender as DropDownList;
       
        ListItem li = new ListItem();
        li = ddl.SelectedItem;
        string s = li.Text;
        Label1.Text = s;
    }
