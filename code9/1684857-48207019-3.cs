    protected void gvPayment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            EnabledAmtPaidTextBox(e.Row);
        }
    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelect = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chkSelect.NamingContainer;
        EnabledAmtPaidTextBox(row, chkSelect.Checked);
    }
    private void EnabledAmtPaidTextBox(GridViewRow row, bool? newCheckedOrApplyOld = null)
    {
        TextBox AmtPaid = (TextBox)row.FindControl("AmtPaid");
        Label AmtDue = (Label)row.FindControl("AmtDue");
        CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");
        Dictionary<int, bool> enabledAmtPaidTextBoxes = (Dictionary<int, bool>)ViewState["EnabledAmtPaidTextBoxes"];
        if (!enabledAmtPaidTextBoxes.ContainsKey(row.RowIndex))
            enabledAmtPaidTextBoxes[row.RowIndex] = false;
        if (newCheckedOrApplyOld.HasValue)
            enabledAmtPaidTextBoxes[row.RowIndex] = newCheckedOrApplyOld.Value;
        else 
            chkSelect.Checked = enabledAmtPaidTextBoxes[row.RowIndex];
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
