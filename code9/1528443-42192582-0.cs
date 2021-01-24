    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Text="" Value =""></asp:ListItem>
                <asp:ListItem Text="10 Columns" Value ="1"></asp:ListItem>
                <asp:ListItem Text="5 Columns" Value ="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:GridView runat="server" ID="GridView1" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
        </form>
    </body>
    </html>
    public partial class WebForm3 : System.Web.UI.Page
        {
            private DataTable dtgridbind = new DataTable();
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    foreach (TableCell headerCell in e.Row.Cells)
                    {
                        headerCell.Text = headerCell.Text.Split('_')[1]; 
                    }
                }
            }
    
            protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (DropDownList1.SelectedIndex == 1)
                {
                    dtgridbind.Columns.AddRange(new DataColumn[10] { new DataColumn("1_ALta", typeof(bool)),new DataColumn("1_Hplan", typeof(bool)),
                                new DataColumn("1_Hosp",typeof(bool)),new DataColumn("1_other",typeof(bool)),new DataColumn("1_othercolor",typeof(string)),
                                new DataColumn("2_ALta", typeof(bool)),new DataColumn("2_Hplan", typeof(bool)),
                                new DataColumn("2_Hosp",typeof(bool)),new DataColumn("2_other",typeof(bool)),new DataColumn("2_othercolor",typeof(string))});
                    dtgridbind.Rows.Add(true, false, false, false, "N/A", false, true, false, false, "Red");
                    dtgridbind.Rows.Add(true, false, false, false, "N/A", false, true, false, false, "Red");
                    dtgridbind.Rows.Add(true, false, false, false, "N/A", false, true, false, false, "Red");
                    GridView1.DataSource = dtgridbind;
                    GridView1.DataBind();
                }
                else
                {
                    dtgridbind.Columns.AddRange(new DataColumn[5] { new DataColumn("1_ALta", typeof(bool)),new DataColumn("1_Hplan", typeof(bool)),
                                new DataColumn("1_Hosp",typeof(bool)),new DataColumn("1_other",typeof(bool)),new DataColumn("1_othercolor",typeof(string))});
                    dtgridbind.Rows.Add(true, false, false, false, "N/A");
                    dtgridbind.Rows.Add(true, false, false, false, "N/A");
                    dtgridbind.Rows.Add(true, false, false, false, "Red");
                    GridView1.DataSource = dtgridbind;
                    GridView1.DataBind();
                }
            }
        }
