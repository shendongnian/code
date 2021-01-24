    protected void getDateControls()
        {
            foreach (GridViewRow grow in gdView.Rows)
            {
                System.Web.UI.WebControls.TextBox txtFrom = new System.Web.UI.WebControls.TextBox();
                txtFrom.ID = "txtFrom";
                txtFrom.Width = 70;
                txtFrom.AutoPostBack = true;
                txtFrom.TextChanged += new System.EventHandler(this.txtFrom_Changed);
                grow.Cells[5].Controls.Add(txtFrom);
                System.Web.UI.WebControls.TextBox txtTo = new System.Web.UI.WebControls.TextBox();
                txtTo.ID = "txtTo";
                txtTo.Width = 70;
                txtTo.AutoPostBack = true;
                txtTo.TextChanged += new System.EventHandler(this.txtTo_Changed);
                grow.Cells[6].Controls.Add(txtTo);
            }
        }
