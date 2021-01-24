    protected void gvPayment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            EnabledAmtPaidTextBox(e.Row);
        }
    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
        EnabledAmtPaidTextBox(row, chkSelect.Checked);
    }
    private void EnabledAmtPaidTextBox(GridViewRow row, bool? newValue = null)
    {
        TextBox AmtPaid = (TextBox)row.FindControl("AmtPaid");
        Label AmtDue = (Label)row.FindControl("AmtDue");
        
        Dictionary<int, bool> enabledAmtPaidTextBoxes = (Dictionary<int, bool>)ViewState["EnabledAmtPaidTextBoxes"];
        if (newValue.HasValue)
            enabledAmtPaidTextBoxes[row.RowIndex] = newValue.Value;
        else if(!enabledAmtPaidTextBoxes.ContainsKey(row.RowIndex))
            enabledAmtPaidTextBoxes[row.RowIndex] = false;
        if (enabledAmtPaidTextBoxes[row.RowIndex])
        {
            AmtPaid.Text = AmtDue.Text.Replace(",", "");
            AmtPaid.Attributes.Remove("readonly");
        }
        else
        {
            AmtPaid.Text = string.Empty;
            AmtPaid.Attributes.Add("readonly", "readonly");
        }
    }
