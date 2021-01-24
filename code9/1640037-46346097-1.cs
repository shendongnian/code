    private void LoadTodaysExpensesByTill(int tillID)
    {
        DataTable dt = new DataTable();
        dt = new TillEndOfDayDAL().GetTodaysExpensesByTillID(tillID);
        pnlTillExpenseRegistration.Visible = false;
        if (dt != null && dt.Rows.Count > 0)
        {
            gvTillExpenseRegistration.DataSource = dt;        
            pnlTillExpenseRegistration.Visible = true;
        }
        gvTillExpenseRegistration.DataBind();
    }
