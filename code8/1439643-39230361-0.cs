    protected void cbPaid_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbPaid = sender as CheckBox;
    
        if (cbPaid != null && cbPaid.Parent != null)
        {
            GridViewRow row = cbPaid.Parent.Parent as GridViewRow;
    
            if (row != null )
            {
                string status = "Paid";
                int amount = Convert.ToInt32(ViewState["EventFee"]);
                DateTime date = DateTime.Now;
                string user = Session["user_id"].ToString();
                string regID = row.Cells[2].Text;
    
                string type = "Deposit";
                string account = "Participation";
                int balance = BAL.fetch_availableBalance();
                int total_balance = amount + balance;
                string detail = "Participant: " + regID + " fee has been Recieved";
                BAL.updateParticipants(regID, status, amount, user, date);
                BAL.saveBudgetTracking(type, account, amount, 0, total_balance, detail, date);
                Response.Redirect("~/show_members.aspx");
            }
        }
                
    }
