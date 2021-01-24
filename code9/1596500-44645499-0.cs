        RepeaterItem items = ((sender as LinkButton).Parent as RepeaterItem);
        foreach (RepeaterItem itm in items.Controls)
        {
            CheckBox chk = (CheckBox)itm.FindControl("cbticketSelect");
           
            if (chk.Checked)
            {
                Lable1.Text = "Do something ";
                // Do something here
            }
        }
    }
