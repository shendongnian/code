    void ping_PingCompleted(object sender, PingCompletedEventArgs e)//, int column)
    {
        var reply = e.Reply;
        DataGridViewCell cell = e.UserState as DataGridViewCell;
        if (reply != null && cell.RowIndex > -1)
        {
            if (reply.Status.ToString() == "Success")
            {
                cell.Style.BackColor = Color.Green;
            }
            else
            {
                cell.Style.BackColor = Color.Red;
            }
            cell.Value = reply.Status;
        }
        else if (cell.RowIndex > -1)
        {
            cell.Style.BackColor = Color.Red;
            cell.Value = "Unexpected error";
        }
    }
