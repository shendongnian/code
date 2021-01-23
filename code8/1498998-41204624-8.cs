        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
           // Code to generate Excel
            pnlStatus.Visible = false;
            lblPageStatus.Text = string.Empty;
        }
        else
        {
            pnlStatus.Visible = true;
            lblPageStatus.Text = "No data available to export.";
        }
