    using System.Web.UI.WebControls;
    private void resetAllTextBoxes(Panel pnlAddNewPeopleRecord)
    {
        foreach(var control in pnlAddNewPeopleRecord.Controls.OfType<TextBox>())
        {
            control.Text = string.Empty; 
        }
    }
