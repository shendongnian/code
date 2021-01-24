    Foreach(DataGridViewRow row in DataGridView.Rows)
    {
      if(radioButtonDeposit.isChecked())
      {
        if(row["TransactionType"].Value == Enum.Deposit)
        {
           row.Visible = true;
        }
        else
        {
           row.Visible = false;
        }
      }
      else if(radioButtonWithdrawal.isChecked())
      {
        if(row["TransactionType"].Value == Enum.Withdrawal)
        {
           row.Visible = true;
        }
        else
        {
          row.Visible = false;
        }
      }
      else 
        row.Visible = true;            
    }
