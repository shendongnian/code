        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder xTokens = new StringBuilder();
            GridCell[] xCell = xgvCalendar.GetSelectedCells();
            for (int i = 0; i < xCell.Count(); i++)
            {
                int xRow = xCell[i].RowHandle;
                xTokens.Append(dtpTransDate.Value.ToString("MMMM") + " " + xgvCalendar.GetRowCellValue(xRow, xCell[i].Column.ToString()).ToString() + ", " + dtpTransDate.Value.ToString("yyyy"));
                if (i != xCell.Count()-1) xTokens.Append(" - ");
            }
            MessageBox.Show(xTokens.ToString());
        }
