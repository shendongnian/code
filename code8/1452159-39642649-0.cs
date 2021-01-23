    foreach (var item in pnl.Controls)
       {
          if(item.GetType() == typeof(ModDataGridView))
           {
              txt.AppendText(item.GetType().ToString());
           }
       }
