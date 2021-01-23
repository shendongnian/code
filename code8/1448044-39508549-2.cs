        public void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
         ...
          //No need to check/validate the new row
          if (gridSender.Rows[e.RowIndex].IsNewRow)
          {
           return;
          }
          ...
          if(!decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("de-DE").NumberFormat, out result))
          {
           e.Cancel = true;
          }
          ...
         }
        
