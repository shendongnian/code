    foreach (GridViewRow row in gvPizzaOrder.Rows)
    {
        CheckBox chk = row.Cells[0].Controls[1] as CheckBox;
        if (chk.Checked)
        {
            check++;
            TextBox quantity = row.Cells[3].Text as TextBox;
            if (quantity.Text == "")
            {
                return false;
             }
         }
    }
