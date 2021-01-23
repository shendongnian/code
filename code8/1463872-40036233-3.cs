    protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            //Here you write databind logic
            // Datasource table of GridView1 should contain 'HasAtt' and 'id' as its binded to label.
        }
        private void ViewAttachment(int id)
        {
            //Here you write your logic to view attachment.
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow) // checking if row is datarow or not
            {
                Label lblHasAtt = e.Row.FindControl("lblAtt") as Label;
                LinkButton lbtnViewAtt = e.Row.FindControl("lbtnAtt") as LinkButton;
                lbtnViewAtt.Visible = (lblHasAtt.Text.ToLower() == "yes");
            }
        }
        protected void lbtnAtt_Click(object sender, EventArgs e)
        {
            LinkButton lbtnViewAtt = sender as LinkButton;
            GridViewRow grw = lbtnViewAtt.NamingContainer as GridViewRow;
            int id = Convert.ToInt32(this.GridView1.Rows[grw.RowIndex].Cells[0].Text); // retriving value of first column on 'lbtnAtt' click row.
            this.ViewAttachment(id);
        }
