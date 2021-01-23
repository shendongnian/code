        public void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
         ...
         if(decimal.TryParse(grid.EditingControl.Text, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("de-DE").NumberFormat, out decimalValue))
         {
          grid.EditingControl.Text = decimalValue.ToString("#", CultureInfo.CreateSpecificCulture("de-DE").NumberFormat);
         }
         ...
        }
