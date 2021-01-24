    protected void BtnCleanUp_Click(object sender, EventArgs e)
    {
        string sql4 = @"DELETE FROM medicine; DELETE FROM batch_number;";
        if (DBMgr.ExecuteSQL(sql4) >= 1)
        {
            LtlDatabaseMessage.Text = "Deletion successful";
        }
        else
        {
            LtlDatabaseMessage.Text = "Unexpected error";
        }
    }
