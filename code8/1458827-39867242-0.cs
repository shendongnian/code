         DateTime stockDate;
         if (DateTime.TryParse(dr.Cells[4].Value.ToString(), out stockDate))
         {
             dateTimePicker1.Value = stockDate;
         }
