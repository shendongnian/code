        decimal totalValue = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView row = e.Row.DataItem as DataRowView;
                totalValue += Convert.ToDecimal(row["tocht_id"]);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (totalValue == 100)
                {
                    Button button = e.Row.FindControl("btnUpdatePCTD") as Button;
                    button.Enabled = false;
                }
                Label label = e.Row.FindControl("grandTotalPCT") as Label;
                label.Text = string.Format("{0:N2}", GridView1.Rows.Count);
            }
        }
