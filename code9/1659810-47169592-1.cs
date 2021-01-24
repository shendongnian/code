     private void numUpDown_ValueChanged(object sender, EventArgs e)
     {
           bs.CurrencyManager.Position = (int)numUpDown.Value;
           dg.CurrentCell = dg.Rows[Math.Min(dg.CurrentRow.Index + bs.CurrencyManager.Position, dg.Rows.Count - 1)].Cells[dg.CurrentCell.ColumnIndex];
               
     }
               
