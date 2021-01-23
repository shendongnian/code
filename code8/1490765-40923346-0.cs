    {
               if (DataBinder.Eval(e.Row.DataItem, "n1") == 0)
                {
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    e.Row.Cells[1].BackColor = System.Drawing.Color.White;
                }
    }
