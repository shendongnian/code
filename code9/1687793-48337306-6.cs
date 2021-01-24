    protected void DayButton_Click(object sender, EventArgs e)
    {
        HtmlTableRow TR = new HtmlTableRow;
        HtmlTableCell TD1 = new HtmlTableCell;
        TD1.Attributes.Add("style", "text-align:right;");
        TD1.InnerHtml = "<p>Day " + txtLeaveTakenDays.Text + " : </p>";
        HtmlTableCell TD2 = new HtmlTableCell;
        TextBox TB = new TextBox;
        TB.ID = "DayDateDay" + txtLeaveTakenDays.Text;
        TB.Attributes.Add("style", "text-align:center;");
        TB.Width = 210;
        TB.Text = txtLeaveTakenDays.Text;
        TD2.Controls.Add(TB);
        TR.Controls.Add(TD1);
        TR.Controls.Add(TD2);
        DayTable.Controls.Add(TR);
    }
