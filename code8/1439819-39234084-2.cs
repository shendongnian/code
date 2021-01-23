    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        if (CheckWireFromValidation() && CheckWireToValidation())
        {
            Response.Redirect("~/DashBoard.aspx");
        }
    }
    public bool CheckWireFromValidation ()
    {
        if (drpFromCoporate.SelectedIndex != 0 || drpFromCapital.SelectedIndex != 0 || drpFromProperty.SelectedIndex != 0)
        {
            return true;
        }
        else
        {          
            ShowAlertMessage("You need to choose at least one filed from Wire From drop downs!!");
            return false;
        }         
    }
    public bool CheckWireToValidation ()
    {
        if (drpToCapital.SelectedIndex != 0 || drpToCoporate.SelectedIndex != 0 || drpToProperty.SelectedIndex != 0 || drpToTemplate.SelectedIndex != 0 || txtCorpAmt.Text != "" || txtCapAmt.Text != "" || txtPropAmt.Text != "" || txtTempelateAmt.Text != "")
        {
            return true;
        }
        else
        {
            ShowAlertMessage("You need to choose at least one filed from Wire To drop downs!!");
            return false;
        }     
    }
