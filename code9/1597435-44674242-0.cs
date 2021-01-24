    // if the input of amount is not empty assign amount  to a conversion integer of txtAmount.Text
    if (txtAmount.Text != "")
    {
        try
        {
            amount = Convert.ToInt32(txtAmount.Text);
            hBos.setWithdrawls(amount);
        }
        catch (Exception ex)
        {
            resultLbl.Text = ex.Message;
            return;
        }
    }
