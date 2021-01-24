    DataTable dt = new DataTable;
    bool success = true;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        string date = dt.Rows[i]["Date"].ToString();
        string[] date1 = date.Split('/');
        string month = date1[0];
        string year = date1[2];
        if (month != txtmonth.Text || year != txtyear.Text)
        {
            success = false;
            break;
        }
    }
    if (success)
    {
        lblmessage("You Uploaded Valid document");
    }
    else
    {
        lblmessage("You Uploaded is not Valid document");
    }
