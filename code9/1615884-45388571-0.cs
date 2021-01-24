    <asp:GridView ID="GridView1" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
               RowStyle-BackColor="White"
               runat="server" AutoGenerateColumns="false" OnRowDataBound = "OnRowDataBound">
               <Columns>
                   <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="150" />
                   <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="150" />
               </Columns>
           </asp:GridView>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Country"), new DataColumn("Name") });
            dt.Rows.Add("USA", "John Hammond");
            dt.Rows.Add("USA", "Suzanne Mathews");
            dt.Rows.Add("Russia", "Robert Schidner");
            dt.Rows.Add("India", "Vijay Das");
            dt.Rows.Add("India", "Mudassar Khan");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
     
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex > 0)
            {
                GridViewRow previousRow = GridView1.Rows[e.Row.RowIndex - 1];
                if (e.Row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        previousRow.Cells[0].RowSpan += 2;
                        e.Row.Cells[0].Visible = false;
                    }
                }
            }
        }
    }
