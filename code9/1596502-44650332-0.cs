    protected void donateButton_Click(object sender, EventArgs e)
    {
        string checkedBoxes = "";
        foreach (RepeaterItem item in rptTicketsInPerformance.Items)
        {
            CheckBox cb = item.FindControl("cbticketSelect") as CheckBox;
            checkedBoxes += cb.Checked.ToString() + ", ";
        }
        Label1.Text = checkedBoxes;
    }
