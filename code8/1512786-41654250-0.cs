    decimal sum = 0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView row = e.Row.DataItem as DataRowView;
            sum += Convert.ToDecimal(row["totalFee"]);
            TextBox1.Text = string.Format("{0:C2}", sum);
        }
    }
