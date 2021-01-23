        string radioValue = "";
        foreach (TableRow dr in MeetingsTable.Rows)
        {
            int countControls = dr.Cells[0].Controls.Count;
            if (countControls != 0)
            {
                RadioButton r = dr.Cells[0].Controls[0] as RadioButton;
                if (r.Checked)
                    radioValue = r.Text;
            }
        }
        return radioValue;
    }
