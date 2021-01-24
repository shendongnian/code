            private void btnUp_Click(object sender, EventArgs e)
            {
                int rowIndex = gridEX1.CurrentRow.RowIndex - 1;
                selectRow(rowIndex);
            }
    
            private void btnDown_Click(object sender, EventArgs e)
            {
                int rowIndex = gridEX1.CurrentRow.RowIndex + 1;
                selectRow(rowIndex);
            }
    
            private void selectRow(int rowIndex)
            {
                gridEX1.Focus(); //set the focus back on your grid here
                if (rowIndex >= 0 && rowIndex < (gridEX1.RowCount))
                {               
                    GridEXRow newSelectedRow = gridEX1.GetRow(rowIndex);
                    gridEX1.MoveToRowIndex(rowIndex);               
                }
            }
