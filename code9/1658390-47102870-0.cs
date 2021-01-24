    protected void btnSum_Click(object sender, EventArgs e)
    {
        int a = Int32.Parse(ddlEval1.SelectedItem.ToString());
        int b = Int32.Parse(ddlEval2.SelectedItem.ToString());
        int c = Int32.Parse(ddlEval3.SelectedItem.ToString());
        int d = Int32.Parse(ddlEval4.SelectedItem.ToString());
        int f = Int32.Parse(ddlEval5.SelectedItem.ToString());
        txtScore.Text = Convert.ToString(a + b + c + d + f);
    }
