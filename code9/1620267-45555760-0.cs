    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        if (tools13.Rows.Count > 0)
        {
            e.Row.BackColor = ColorTranslator.FromHtml(tools13.Rows[0]["Colors"].ToString());
            //or by column index instead of by name
            e.Row.BackColor = ColorTranslator.FromHtml(tools13.Rows[0][1].ToString());
        }
    }
